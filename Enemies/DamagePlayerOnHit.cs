using UnityEngine;
using System.Collections;

public class DamagePlayerOnHit : MonoBehaviour {
	public int amount = 5;

	void Start(){
		if (!collider) {
			Debug.LogWarning ("Gameobject " + transform.name + " does not have a collider but has a on-hit script!");
		}
	}
	
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
	void Hit(GameObject c){
		if(c.CompareTag("Player")){
			PlayerScript pscript = c.GetComponent<PlayerScript>() as PlayerScript;
			if(pscript){
				pscript.Hit(amount);
			}
		}
	}
}
