using UnityEngine;
using System.Collections;

// Require these components when using this script
[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]
public class MixedControlScript : MonoBehaviour
{
	public float animSpeed = 1.5f;				// a public setting for overall animator animation speed
	public float lookSmoother = 3f;				// a smoothing setting for camera motion
	public bool useCurves;						// a setting for teaching purposes to show use of curves

	private Animator anim;							// a reference to the animator on the character
	private AnimatorStateInfo currentBaseState;		// a reference to the current state of the animator, used for base layer
	private CapsuleCollider col;					// a reference to the capsule collider of the character
	
	static readonly int idleState		= Animator.StringToHash("Base Layer.Idle");	
	static readonly int locoState		= Animator.StringToHash("Base Layer.Locomotion");		// these integers are references to our animator's states
	static readonly int jumpState		= Animator.StringToHash("Base Layer.Jump");				// and are used to check state for various actions to occur
	static readonly int jumpDownState	= Animator.StringToHash("Base Layer.JumpDown");			// within our FixedUpdate() function below
	static readonly int fallState		= Animator.StringToHash("Base Layer.Fall");
	static readonly int rollState		= Animator.StringToHash("Base Layer.Roll");

	// Dejo el slot para elegir la camara. Lo ideal seria que lo haga automatico buscando la camara como child.
	public Camera myPlayerCamera; 


	void Start ()	{
		// initialising reference variables
		anim = GetComponent<Animator>();					  
		col = GetComponent<CapsuleCollider>();				
		if(anim.layerCount ==2)
			anim.SetLayerWeight(1, 1);
	}
		
	void FixedUpdate ()	{
		float h = Input.GetAxis("Horizontal");					// setup h variable as our horizontal input axis
		float v = Input.GetAxis("Vertical");					// setup v variables as our vertical input axis
		anim.SetFloat("Speed", v);								// set our animator's float parameter 'Speed' equal to the vertical input axis				
		anim.SetFloat("Direction", h); 							// set our animator's float parameter 'Direction' equal to the horizontal input axis		
		anim.speed = animSpeed;									// set the speed of our animator to the public variable 'animSpeed'
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);	// set our currentState variable to the current state of the Base Layer (0) of animation
		
		//--------------------------------------------------------------------
		// STANDARD JUMPING
		//--------------------------------------------------------------------
		// if we are currently in a state called Locomotion (see line 25), then allow Jump input (Space) to set the Jump bool parameter in the Animator to true
		if (currentBaseState.nameHash == locoState){
			if(Input.GetButtonDown("Jump")){
				anim.SetBool("Jump", true);
			}
		}
		
		// if we are in the jumping state... 
		else if(currentBaseState.nameHash == jumpState){
			//  ..and not still in transition..
			if(!anim.IsInTransition(0)){
				if (useCurves){
					// ..set the collider height to a float curve in the clip called ColliderHeight
					col.height = anim.GetFloat("ColliderHeight");
				}
				// reset the Jump bool so we can jump again, and so that the state does not loop 
				anim.SetBool("Jump", false);
			}
			
			// Raycast down from the center of the character.. 
			Ray ray = new Ray(transform.position + Vector3.up, -Vector3.up);
			RaycastHit hitInfo = new RaycastHit();
			
			if (Physics.Raycast(ray, out hitInfo)){
				// ..if distance to the ground is more than 1.75, use Match Target
				if (hitInfo.distance > 1.75f){
					// MatchTarget allows us to take over animation and smoothly transition our character towards a location - the hit point from the ray.
					// Here we're telling the Root of the character to only be influenced on the Y axis (MatchTargetWeightMask) and only occur between 0.35 and 0.5
					// of the timeline of our animation clip
					anim.MatchTarget(hitInfo.point, Quaternion.identity, AvatarTarget.Root, new MatchTargetWeightMask(new Vector3(0, 1, 0), 0), 0.35f, 0.5f);
				}
			}
		}

		//--------------------------------------------------------------------
		// JUMP DOWN AND ROLL 
		//--------------------------------------------------------------------
		// if we are jumping down, set our Collider's Y position to the float curve from the animation clip - 
		// this is a slight lowering so that the collider hits the floor as the character extends his legs
		else if (currentBaseState.nameHash == jumpDownState){
			col.center = new Vector3(0, anim.GetFloat("ColliderY"), 0);
		}
		
		// if we are falling, set our Grounded boolean to true when our character's root 
		// position is less that 0.6, this allows us to transition from fall into roll and run
		// we then set the Collider's Height equal to the float curve from the animation clip
		else if (currentBaseState.nameHash == fallState){
			col.height = anim.GetFloat("ColliderHeight");
		}
		
		// if we are in the roll state and not in transition, set Collider Height to the float curve from the animation clip 
		// this ensures we are in a short spherical capsule height during the roll, so we can smash through the lower
		// boxes, and then extends the collider as we come out of the roll
		// we also moderate the Y position of the collider using another of these curves on line 128
		else if (currentBaseState.nameHash == rollState){
			if(!anim.IsInTransition(0)){
				if(useCurves)
					col.height = anim.GetFloat("ColliderHeight");
				col.center = new Vector3(0, anim.GetFloat("ColliderY"), 0);
			}
		}

		//--------------------------------------------------------------------
		// IDLE
		//--------------------------------------------------------------------
		// check if we are at idle, if so, let us Wave!
		else if (currentBaseState.nameHash == idleState){
			if(Input.GetButtonUp("Jump")){
				anim.SetBool("Wave", true);
			}
		}
		
	}

	//-------------------------------------------------------------------------------------------------------
	//Sprinter data
	
	
	void MovementManagement(float horizontal, float vertical)
	{
		// Call function that deals with player orientation.
		Rotating(horizontal, vertical);
		/*
		// Set proper speed.
		Vector2 dir = new Vector2(horizontal, vertical);
		speed = Vector2.ClampMagnitude(dir, 1f).magnitude;
		// This is for PC only, gamepads control speed via analog stick.
		speedSeeker += Input.GetAxis("Mouse ScrollWheel");
		speedSeeker = Mathf.Clamp(speedSeeker, walkSpeed, runSpeed);
		speed *= speedSeeker;
		if (behaviourManager.IsSprinting())
		{
			speed = sprintSpeed;
		}

		behaviourManager.GetAnim.SetFloat(speedFloat, speed, speedDampTime, Time.deltaTime);
		*/
	}

	Vector3 Rotating(float horizontal, float vertical)
	{
		// Get camera forward direction, without vertical component.
		Vector3 forward = myPlayerCamera.transform.TransformDirection(Vector3.forward);

		// Player is moving on ground, Y component of camera facing is not relevant.
		forward.y = 0.0f;
		forward = forward.normalized;

		// Calculate target direction based on camera forward and direction key.
		Vector3 right = new Vector3(forward.z, 0, -forward.x);
		Vector3 targetDirection;
		targetDirection = forward * vertical + right * horizontal;

		/*
		// Lerp current direction to calculated target direction.
		if ((behaviourManager.IsMoving() && targetDirection != Vector3.zero))
		{
			Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

			Quaternion newRotation = Quaternion.Slerp(behaviourManager.GetRigidBody.rotation, targetRotation, behaviourManager.turnSmoothing);
			behaviourManager.GetRigidBody.MoveRotation(newRotation);
			behaviourManager.SetLastDirection(targetDirection);
		}
		// If idle, Ignore current camera facing and consider last moving direction.
		if (!(Mathf.Abs(horizontal) > 0.9 || Mathf.Abs(vertical) > 0.9))
		{
			behaviourManager.Repositioning();
		}
		*/
		return targetDirection;
	}
	
	//-------------------------------------------------------------------


	}