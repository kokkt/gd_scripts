using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float max_hp = 50;
	public float hp;
	public int xp_gain = 2;
	// Use this for initialization
	void Start () {
		hp = max_hp;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void TakeDamage(float amount){
		hp -= amount;
		if (hp <= 0) {
			Die();
		}
	}
	public void Die(){
		Experience xp = PlayerScript.GetAttribute (typeof(Experience)) as Experience;
		xp.GainXP (xp_gain);
		Destroy(gameObject);
	}
}
