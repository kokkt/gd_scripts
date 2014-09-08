using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public int max_hp = 100;
	public int hp = 0;
	float lifeTime = 0.0f;

	// Use this for initialization
	void Start () {
		tag = "Player";
		hp = max_hp;	
	}

	void Update(){
		lifeTime += Time.deltaTime;
	}
	public void Hit(int damage){
		hp -= damage;
		if (hp <= 0) {
			GameOver(false);
		}

	}
	public void GameOver(bool win){
		/* Insert code that happens when the game is over */
		Application.LoadLevel ("GameOver");

	}
	void OnGUI(){
		GUILayout.Space (64);
		GUILayout.Label ("HP " + hp);
		GUILayout.Label ("Lifetime " + lifeTime);
	}
}
