using UnityEngine;
using System.Collections;

public class Score : PlayerAttribute
{
    public int score = 0;

	// Use this for initialization
    void Start()
    {
        score = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void AddScore(int amount)
    {
        score += amount;
    }
    public override string GetUIString()
    {
        return "";
    }
}
