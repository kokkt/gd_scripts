using UnityEngine;
using System.Collections;

public class ExtraLifeCollectable : MonoBehaviour {
	int extraLives = 1;
	
	void Start () {
		if (!collider.isTrigger) {
			collider.isTrigger = true;
		}
	}
	
	void OnTriggerEnter(Collider c){
		if (c.CompareTag ("Player")) {
			c.GetComponent<PlayerScript>().AddLives(extraLives);
			Destroy (gameObject);
		}
	}
}
