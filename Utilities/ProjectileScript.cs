using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<Rigidbody> ();
	}

	void OnCollisionEnter(Collision c){
		c.collider.SendMessage ("Damage", 1);
		Destroy (gameObject);
	}
}
