using UnityEngine;
using System.Collections;

public class GameobjectSpawner : MonoBehaviour {
	public Transform objectToSpawn;
	public float spawnRate = 0.2f;
	public float increasePerSpawn = 0.01f;
	public Vector3 launchDirection = new Vector3(0,0,0);
	public Vector3 launchVariation = new Vector3(0,0,0);
	public Vector3 spawnVariation = new Vector3 (0, 0, 0);
	float elapsedTime = 0.0f;
	Vector3 spawnPos = new Vector3(0, 0, 0);
	Vector3 launchDir = new Vector3(0,0,0);

	void Update () {
	if (elapsedTime > 1.0f/spawnRate) {
			spawnPos = transform.position;
			spawnPos = AddVariance(spawnPos, spawnVariation);
			Object obj = Instantiate(objectToSpawn, spawnPos, objectToSpawn.rotation);
			Rigidbody rBody = (obj as Transform).rigidbody;
			if(rBody){
				launchDir = launchDirection;
				launchDir = AddVariance(launchDir, launchVariation);

				rBody.velocity = transform.TransformDirection(launchDir);

			}
			elapsedTime = 0;
			spawnRate += increasePerSpawn;
			GameobjectCounter.gameObjects++;
		}
		elapsedTime += Time.deltaTime;
	}
	private Vector3 AddVariance(Vector3 original, Vector3 variation){
			if (variation.x != 0 || variation.y != 0 || variation.z != 0) {
				original.x += Random.Range (variation.x / -2, variation.x / 2);				
				original.y += Random.Range (variation.y / -2, variation.y / 2);				
				original.z += Random.Range (variation.z / -2, variation.z / 2);
			}
		return original;
		}

	void OnDrawGizmos(){
		Gizmos.DrawRay (new Ray (transform.position, transform.TransformDirection(launchDirection)));
	}
}
