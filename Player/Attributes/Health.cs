using UnityEngine;
using System.Collections;

public class Health : PlayerAttribute
{
    public int max_hp = 100;
    public int hp = 0;
    static public int maxlives = 3;
    static int lives = maxlives;

	// Use this for initialization
    void Start()
    {
        hp = max_hp;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Hit(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Die();
        }

    }
    public void AddLives(int amount)
    {
        lives += amount;
    }
    public void Die()
    {
        lives--;
        if (lives <= 0)
        {
            SendMessage("GameOver", false);
        }
        else
        {
            GameObject spawnObj = GameObject.FindWithTag("Respawn");
            if (!spawnObj)
            {
                Debug.LogWarning("Player spawn not found, it's Game Over");
                SendMessage("GameOver", false);
            }
            else
            {
                spawnObj.GetComponent<PlayerSpawn>().Spawn();
            }
        }


    }
    public void GameOver(bool win)
    {
        lives = maxlives;
    }
    public override string GetUIString()
    {
        return "HP\t"+hp+"/"+max_hp;
    }
}
