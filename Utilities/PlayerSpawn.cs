using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {
	public Transform playerPrefab;

	// Use this for initialization
	void Start () {
		gameObject.name = "Player Spawn";
		gameObject.tag = "Respawn";
		Spawn ();
	}

	public void Spawn(){
		if (!playerPrefab) {
			Debug.LogError("Player prefab is not set for PlayerSpawn: Drag the player Prefab to the script.");
			return;
		}
		GameObject player = GameObject.FindWithTag ("Player");
		if (player) {
			GameObject.Destroy(player);
		}
		GameObject.Instantiate (playerPrefab, transform.position, transform.rotation);
	}
	public void Respawn (GameObject player){
		player.transform.position = transform.position;
		}
}
