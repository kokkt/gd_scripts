using UnityEngine;
using System.Collections;

public class ProjectileThrower : MonoBehaviour {
	public float rateOfFire = 1.0f;
	public float bulletSpeed = 2.0f;
	public GameObject projectile;
	float timeBetweenShots = 0.0f;

	void Update(){
		timeBetweenShots += Time.deltaTime;
		if (Input.GetAxis("Fire1") > 0 && timeBetweenShots > rateOfFire) {
			Rigidbody bullet;
			bullet = GameObject.Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
			bullet.velocity = transform.TransformDirection(Vector3.forward * 10);
			bullet.gameObject.AddComponent<ProjectileScript>();
			//bullet.rigidbody.AddForce(transform.forward * bulletSpeed);
			timeBetweenShots = 0;
		}

	}
}
