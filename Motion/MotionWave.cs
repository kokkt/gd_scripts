using UnityEngine;
using System.Collections;

public class MotionWave : MotionPattern{
	public enum Method {Sin, Cos, Tan}
	public Method method = Method.Sin;
	public Vector3 direction = new Vector3 ();
	public float waveFrequency = 1;
	float easing = 0.1f;
	float frame = 0;
	float waveFactor = 0;
	
	// Update is called once per frame
	void Update () {
		switch (method) {
				case Method.Cos:
						waveFactor = Mathf.Cos (frame);
						break;
				case Method.Sin:
						waveFactor = Mathf.Sin (frame);
						break;
				case Method.Tan:
						waveFactor = Mathf.Tan (frame);
						break;
				}
		transform.Translate (direction*waveFactor*easing);
		frame += waveFrequency*Time.deltaTime;
	}
}
