﻿using UnityEngine;
using System.Collections;

public class ProjectileThrower : MonoBehaviour {
	public float rateOfFire = 1.0f;
    public float levelMultiplier = 1.1f;
	public float bulletSpeed = 2.0f;
	public GameObject projectile;
    float timeBetweenShots = 0.0f;
    float lvlMult = 1.0f;
    Experience xp;

    void Start()
    {
        xp = GetComponent<Experience>();
    }

	void Update(){
        if (xp)
        {
            lvlMult = levelMultiplier*xp.Level;
        }
		timeBetweenShots += Time.deltaTime;
		if (Input.GetAxis("Fire1") > 0 && timeBetweenShots > rateOfFire*levelMultiplier) {
			Rigidbody bullet;
			bullet = GameObject.Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
			if(bullet != null){
				bullet.velocity = transform.TransformDirection(Vector3.forward * 10);
				bullet.gameObject.AddComponent<ProjectileScript>();
			}
			//bullet.rigidbody.AddForce(transform.forward * bulletSpeed);
			timeBetweenShots = 0;
		}

	}
}
