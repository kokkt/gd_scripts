using UnityEngine;
using System.Collections;

public class Experience : PlayerAttribute
{
    public int xpUntilNextLevel = 3;
    int level = 1;
    int xp = 0;
    public  int Level { get { return level; } }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void GainXP(int amount)
    {
        xp += amount;
        while (xp > xpUntilNextLevel)
        {
            level++;
            LevelUp();
            xp -= xpUntilNextLevel;
            xpUntilNextLevel *= level / 2;
        }
    }
    void LevelUp()
    {
        SendMessage("OnLevelUp", level);
    }
    public override string GetUIString()
    {
        return "";
    }
}
