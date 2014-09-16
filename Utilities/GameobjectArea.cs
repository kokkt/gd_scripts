using UnityEngine;
using System.Collections;

public class GameobjectArea : MonoBehaviour {
	public bool destroyPlayer = false;
	// Use this for initialization
	void Start () {
		if (!collider.isTrigger) {
			collider.isTrigger = true;
		}
	}

	void OnTriggerExit(Collider c){
		Hit (c.gameObject);
	}
	void OnTriggerExit2D(Collider2D c){
		Hit (c.gameObject);
	}
	
	private void Hit(GameObject c){
		if (c.CompareTag ("Player") && !destroyPlayer) {
			PlayerHit ();
		} else {
			Destroy(c.gameObject);
			GameobjectCounter.gameObjects--;
		}
	}
	public void PlayerHit(){
		/* Insert code that happens when the player tagged object is hit here */
		GameObject.FindWithTag ("Player").GetComponent<PlayerScript> ().Die ();
	}
}
