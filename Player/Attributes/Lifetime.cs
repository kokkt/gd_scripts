using UnityEngine;
using System.Collections;

public class Lifetime : PlayerAttribute {
    static public float lifeTime = 0.0f;
	// Use this for initialization
    void Start()
    {
        lifeTime = 0;
	
	}
	
	// Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
	
	}
    public override string GetUIString()
    {
        return "";
    }
}
