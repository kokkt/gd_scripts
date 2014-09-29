using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class Torch : MonoBehaviour {
	public float intensity = 1.0f;
	public float intensityJitter = 0.2f;
	public float torchRange = 10.0f;
	public Color torchColor = new Color(255,255,255);
	Light lightObj;
	// Use this for initialization
	void Start () {
		lightObj = gameObject.AddComponent<Light> ();
		lightObj.type = LightType.Point;
		lightObj.intensity = intensity;
	
	}
	
	// Update is called once per frame
	void Update () {
		lightObj.range = torchRange;
		lightObj.color = torchColor;
		lightObj.intensity = intensity + Random.Range (-intensityJitter, intensityJitter);
	
	}
}
