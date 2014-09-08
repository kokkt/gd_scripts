using UnityEngine;
using System.Collections;

public class GameobjectDestroyer : MonoBehaviour {
	public bool destroyPlayer = false;
	void OnCollisionEnter(Collision c){
		Hit (c.collider.gameObject);
	}

	void OnTriggerEnter(Collider c){
		Hit (c.collider.gameObject);
	}

	void OnCollisionEnter2D(Collision2D c){
		Hit (c.collider.gameObject);		
	}

	void OnTriggerEnter2D(Collider2D c){
		Hit (c.collider.gameObject);		
	}

	private void Hit(GameObject c){
		Debug.Log (c.tag);
		if (c.CompareTag ("Player") && !destroyPlayer) {
				PlayerHit ();
		} else {
			Destroy(c.gameObject);
			GameobjectCounter.gameObjects--;
		}
	}
	public void PlayerHit(){
		/* Insert code that happens when the player tagged object is hit here */
		Debug.Log ("Player hit");
		GameObject.FindWithTag ("Player").GetComponent<PlayerScript> ().GameOver (false);
	}
}
