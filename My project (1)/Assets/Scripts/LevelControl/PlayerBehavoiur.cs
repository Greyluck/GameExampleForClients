using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This class manages the movement, shooting and reloading of the player
public class PlayerBehavoiur : MonoBehaviour
{
    // variables 
    private float characterSpeed = 5.0f;
    private float characterLimit = 8.1f;
    
    public Proyectile bulletPrefab;
    public int maxBullets = 15;
    private int bulletInStash = 15;
    
    private float timeRemainingToRecharge = 2;
    private GameObject Aura;
    
    private GameObject ammoText;
	public int newAmmo = 0;
	public GameObject myCanvas;

    // Start is called before the first frame update
    void Start (){
	    Debug.Log("PlayerBehavoiur has started");
        Aura = GameObject.Find("Aura");
        Aura.SetActive(false);

        ammoText = GameObject.Find ("Txt_Ammo");
		myCanvas = GameObject.Find ("Canvas");
    }

    // Update is calles once per frame
    void Update (){
        MovementBasics(); 
        ShootingBasics();
        RelaodingBasics();
    }

    private void MovementBasics(){
        // Basic movement using A and D or using arrows
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) &&  this.transform.position.x>(-characterLimit)){
            this.transform.position += Vector3.left * this.characterSpeed * Time.deltaTime; 
        } else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && this.transform.position.x<characterLimit){
            this.transform.position += Vector3.right * this.characterSpeed * Time.deltaTime; 
        }
    }   


    // The charater has a small quantity of bullets to shoot.
    private void ShootingBasics(){
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetMouseButtonDown(0)){
            if (bulletInStash>0){
                bulletInStash--;
                Shoot();
            } else {
                Debug.Log("NO ammo! Reload needed!");
            }   
        }
    }

    private void Shoot(){
        newAmmo = GlobalManager.restAmmo();
		ammoText.GetComponent<Text> ().text = "Ammo: " + newAmmo;

        Instantiate (this.bulletPrefab, this.transform.position, Quaternion.identity);
        Debug.Log("We Have Shoot! - " + bulletInStash + " bullets remaining" );
    }
    
    
    // The reloading process should take 2 seconds (And will be interrupted if not completed)
    private void RelaodingBasics(){
        if (Input.GetKey(KeyCode.R) && bulletInStash < maxBullets){
            StartReloading();
        }
        if (Input.GetKeyUp(KeyCode.R) && timeRemainingToRecharge < 2)
            AbortReloading();
    }

    private void StartReloading(){ 
        if (timeRemainingToRecharge > 0){
            Aura.SetActive(true);
            timeRemainingToRecharge -= Time.deltaTime;
            Debug.Log("Reloading: " + timeRemainingToRecharge + "seconds remains");    
        } else {
            Aura.SetActive(false);
            bulletInStash=15;

            newAmmo = GlobalManager.reloadAmmo(maxBullets);
    		ammoText.GetComponent<Text> ().text = "Ammo: " + newAmmo;

            Debug.Log("We Have Reloaded! We have " + bulletInStash + " now");
            timeRemainingToRecharge=2;
            }
    }

    private void AbortReloading(){
        Aura.SetActive(false); 
        Debug.Log("Recharge aborted");
        timeRemainingToRecharge=2;        
    }       
}