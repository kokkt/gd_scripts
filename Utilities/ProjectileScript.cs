using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {
	public float lifetimeInSeconds = 2.0f;
	float lifetime = 0;

	// Use this for initialization
	void Start () {
		if (!rigidbody) {
			gameObject.AddComponent<Rigidbody> ();
		}
		lifetime = 0;
	}

	void Update(){
		lifetime += Time.deltaTime;
		if (lifetime > lifetimeInSeconds) {
			Destroy(gameObject);
		}
	}


	void OnCollisionEnter(Collision c){
		c.collider.SendMessage ("Damage", 1);
		Destroy (gameObject);
	}
}
