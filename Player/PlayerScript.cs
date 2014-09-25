using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	static int level = 1;
	static int xp = 0;
	static public int maxlives = 3;
	static public float lifeTime = 0.0f;
	static public int score = 0;
	public static float rateOfFire = 1.0f;
	public int xpUntilNextLevel = 3;
	public int max_hp = 100;
	public int hp = 0;
	public bool displayHP = true;
	public bool displayLives = true;
	public bool displayScore = true;
	public bool displayXP = true;
	public bool displayLevel = true;
	public bool displayLifetime = true;
	public string gameOverScene = "GameOver";
	static int lives = maxlives;


	public static float Level { get { return level;}}
	// Use this for initialization
	void Start () {
		tag = "Player";
		name = "Player";
		hp = max_hp;
		lifeTime = 0;
		score = 0;
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
			Die ();
		}

	}
	public void GameOver(bool win){
		/* Insert code that happens when the game is over */
		lives = maxlives; 
		Application.LoadLevel (gameOverScene);

	}
	public void Die(){
		lives--;
		if (lives <= 0) {
						GameOver (false);
		} else {
			GameObject spawnObj = GameObject.FindWithTag ("Respawn");
			if (!spawnObj) {
					Debug.LogWarning ("Player spawn not found, it's Game Over");
					GameOver (false);
			} else {
					spawnObj.GetComponent<PlayerSpawn> ().Spawn ();
			}
		}

		           
	}
	public void AddScore(int amount){
		score += amount;
	}
	public void AddLives(int amount){
		lives += amount;
	}
	void OnGUI(){
		GUILayout.Space (64);
		if(displayScore)
			GUILayout.Label("Score:\t"+score);
		if (displayHP)
			GUILayout.Label ("HP:\t" + hp);
		if(displayXP)	
		GUILayout.Label ("XP:\t" + xp);
		if (displayLevel)
			GUILayout.Label ("Level:\t" + level);
		if (displayLives)
						GUILayout.Label ("Lives:\t" + lives);
		if (displayLifetime)
		GUILayout.Label ("Lifetime:\t " +(int)lifeTime);
	}
}
