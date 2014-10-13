using UnityEngine;
using System.Collections;

public class DamagePlayerAtDistance : MonoBehaviour {
    public float distance = 1.0f;
    public float damageAmount = 5.0f;
    public float dmgIntervalSeconds = 1.0f;
    public bool checkX = true;
    public bool checkY = true;
    public bool checkZ = true;

    Vector3 checkVector = new Vector3(1,1,1);
    float timer = 0.0f;

	void Start () {
        if (!checkX)
        {
            checkVector.x = 0;
        }
        if (!checkY)
        {
            checkVector.y = 0;
        }
        if (!checkZ)
        {
            checkVector.z = 0;
        }
	
	}
	
	void Update () {
        Vector3 playerPos = PlayerScript.playerObject.transform.position;
        Vector3 thisPos = transform.position;
        playerPos = Vector3.Scale(checkVector, playerPos);
        thisPos = Vector3.Scale(checkVector, thisPos);
        float d = Vector3.Distance(playerPos, thisPos);
        if (d < distance)
        {
            timer += Time.deltaTime;
        }
        if (timer > dmgIntervalSeconds) {
            PlayerScript.playerObject.SendMessageUpwards("Hit", damageAmount);
            timer = 0;
        }
	}

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, distance);
    }
}
