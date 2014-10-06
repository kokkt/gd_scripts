using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class Torch : MonoBehaviour {
	public float intensity = 1.0f;
	public float intensityJitter = 0.2f;
	public float torchRange = 10.0f;
	public Color torchColor = new Color(255,255,255);
	// Use this for initialization
	void Awake () {
		if (!light) {
						gameObject.AddComponent<Light> ();
				}
		light.type = LightType.Point;
		light.intensity = intensity;
	
	}
	
	// Update is called once per frame
	void Update () {
		light.range = torchRange;
		light.color = torchColor;
		light.intensity = intensity + Random.Range (-intensityJitter, intensityJitter);
	
	}
}
