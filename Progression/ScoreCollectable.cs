using UnityEngine;
using System.Collections;

public class ScoreCollectable : MonoBehaviour {
	int scoreAdd = 1;
	
	void Start () {
		if (!collider.isTrigger) {
			collider.isTrigger = true;
		}
	}

	void OnTriggerEnter(Collider c){
		if (c.CompareTag ("Player")) {
			c.GetComponent<PlayerScript>().AddScore(scoreAdd);
			Destroy (gameObject);
		}
	}
}
