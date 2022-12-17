using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour {

	//Variables Generales
	public float volumeScale = 10f;

	//Images
	//public Image musicImage;

	//Botones
	//public Button BtnCoin;
	public Button BtnMusic;

	//Sliders
	//public Slider musicVolume;
	//public Slider soundVolume;

	//AudioClips
	//public AudioClip coinClip;

	//AudioMusicSourse
	public AudioSource musicAudioSource;

	//AudioEffectSourse
	public AudioSource effectAudioSource;

	void Start ()
	{
		//Prende y apaga la musica (o sonido)
		BtnMusic.onClick.AddListener (PlayStopMusic);

		//Activo un sonido
		//BtnCoin.onClick.AddListener (PlayCoin);
	}

	//Cordina que la musica se prenda y se apague
	private void PlayStopMusic()	{
		if (musicAudioSource.isPlaying){
			musicAudioSource.Stop();		
		}else{
			musicAudioSource.Play();
		}
	}

	/*	
	void PlayCoin(){
		effectAudioSource.clip = coinClip;
		effectAudioSource.Play ();
	}

	//---------------------------------------------
	void MusicVolumeChanged(float value){
		musicAudioSource.volume = value;	//Asigna un nuevo valor a la musica
		Color color = musicImage.color;		//Con un slider puedo cambiar varias cosas, como el color:
		color.a = value;
		musicImage.color = color;
	}

	void SoundVolumeChanged(float value)
	{
		effectAudioSource.volume = value;
		effectsAudioSource2.volume = value;
	}*/
}
