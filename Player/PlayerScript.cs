using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	static int level = 1;
	static int xp = 0;
	public static float rateOfFire = 1.0f;
	public int xpUntilNextLevel = 3;
	public int max_hp = 100;
	public int hp = 0;
	float lifeTime = 0.0f;

	public static float Level { get { return level;}}
	// Use this for initialization
	void Start () {
		tag = "Player";
		hp = max_hp;	
	}

	void Update(){
		lifeTime += Time.deltaTime;
	}
	public void GainXP(int amount){
		xp += amount;
		while (xp > xpUntilNextLevel) {
			level++;
			OnLevelUp();
			xp -= xpUntilNextLevel;
			xpUntilNextLevel *= level/2;
		}
	}
	void OnLevelUp(){
		rateOfFire += level;
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
		GUILayout.Label ("Level:\t" + level);
		GUILayout.Label ("XP:\t" + xp);
		GUILayout.Label ("HP:\t " + hp);
		GUILayout.Label ("Lifetime:\t " + lifeTime);
	}
}
