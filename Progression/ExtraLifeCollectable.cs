﻿using UnityEngine;
using System.Collections;

public class ExtraLifeCollectable : MonoBehaviour {
	public int extraLives = 1;
	
	void Start () {
		if (!collider.isTrigger) {
			collider.isTrigger = true;
		}
	}
	
	void OnTriggerEnter(Collider c){
		if (c.CompareTag ("Player")) {
			c.GetComponent<Health>().AddLives(extraLives);
			Destroy (gameObject);
		}
	}
}
