using UnityEngine;
using System.Collections;

public class XPReward : MonoBehaviour {
	public int xpReward = 2;
	public bool destroyOnHit = true;
	
	void Start(){
		if (collider) {
			collider.isTrigger = true;
			
		} else {
			Debug.LogError("Object " + name + " doesn't have a collider. Removing GoalScript.");
			Destroy(this);
		}
	}

	void OnTriggerEnter(Collider c){
		if (c.tag.Equals ("Player")) {
			c.SendMessage ("GainXP", xpReward);
			if (destroyOnHit) {
					Destroy (gameObject);
			}
		}
	}
}
