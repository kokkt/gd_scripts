using UnityEngine;
using System.Collections;

public class MotionWave : MonoBehaviour {
	public enum Method {Sin, Cos, Tan}
	public Method method = Method.Sin;
	public Vector3 direction = new Vector3 ();
	public float waveFrequency = 1;
	float frame = 0;
	float waveFactor = 0;

    void Start()
    {
        if (!transform.parent)
        {
            GameObject newParent = new GameObject();
            newParent.transform.position = transform.position;
            newParent.name = "Wave motion (" + method + ")";
            transform.parent = newParent.transform;
            newParent.AddComponent<DestroyWhenChildless>();
        }

    }

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
		transform.localPosition = direction*waveFactor;
		frame += waveFrequency*Time.deltaTime;
	}
}
