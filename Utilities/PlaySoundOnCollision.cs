using UnityEngine;
using System.Collections;

public class PlaySoundOnCollision : MonoBehaviour {
	public AudioClip sound;

	void Start(){
		if (!audio) {
			gameObject.AddComponent<AudioSource>();
			audio.enabled = true;
		}
	}
	void OnTriggerEnter(Collider c){
		PlaySound ();
	}
	void OnCollisionEnter(Collision c){
		PlaySound ();
	}
	void OnCollisionEnter2D(Collision2D c){
		PlaySound ();
	}

	void PlaySound(){
		AudioSource.PlayClipAtPoint (sound, transform.position);
		//audio.PlayOneShot (sound);
	}
}
