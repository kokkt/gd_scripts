using UnityEngine;
using System.Collections;

public class GameobjectSpawner : MonoBehaviour {
	public Transform objectToSpawn;
	public float spawnRate = 0.2f;
	public float increasePerSpawn = 0.01f;
	public Vector3 spawnVariation = new Vector3(0, 0, 0);
	float elapsedTime = 0.0f;
	Vector3 spawnPos = new Vector3(0, 0, 0);
	
	void Update () {
	if (elapsedTime > 1.0f/spawnRate) {
			spawnPos = transform.position;
			if(spawnVariation.x > 0 || spawnVariation.y > 0){
				spawnPos.x += Random.Range(spawnVariation.x/-2, spawnVariation.x/2);				
				spawnPos.y += Random.Range(spawnVariation.y/-2, spawnVariation.y/2);				
				spawnPos.z += Random.Range(spawnVariation.z/-2, spawnVariation.z/2);
			}
			GameObject.Instantiate(objectToSpawn, spawnPos, objectToSpawn.rotation);
			elapsedTime = 0;
			spawnRate += increasePerSpawn;
			GameobjectCounter.gameObjects++;
		}
		elapsedTime += Time.deltaTime;
	}
}
