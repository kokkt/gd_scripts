using UnityEngine;
using System.Collections;

public class PlaySoundOnCollision : MonoBehaviour {
	public AudioClip sound;

	void Start(){
		if (!audio) {
			gameObject.AddComponent<AudioSource>();
		}
	}
	void OnCollisionEnter(Collision c){
		PlaySound ();
	}
	void OnCollisionEnter2D(Collision2D c){
		PlaySound ();
	}

	void PlaySound(){
		audio.PlayOneShot (sound);
	}
}
