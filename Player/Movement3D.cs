using UnityEngine;
using System.Collections;

public class Movement3D : MonoBehaviour {
    CharacterController cc;
    public float moveSpeed = 15.0f;
    public Vector3 jumpHeight = new Vector3(0, 3f, 0);
    public Vector3 gravity = new Vector3(0, 1f, 0);
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backwardKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jump = KeyCode.Space;
    public bool mouseLook = true;
    public float slopeThreshold = 0.2f;
    Transform lastCollider;
    Vector3 lastColliderPos;
    Vector3 lastColliderDelta = Vector3.zero;
    Vector3 gravityInc = new Vector3();
    Vector3 moveDir = new Vector3();
    bool jumpAvailable = true;
    Vector3 collisionPoint;
    float collisionAngle = -1.0f;
    bool falling = true;
    CapsuleCollider trigger;
	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
        if (!cc)
        {
            cc = gameObject.AddComponent<CharacterController>();
        }
        

        if (mouseLook)
        {
            gameObject.AddComponent<MouseLook>().axes = MouseLook.RotationAxes.MouseX;
            GetComponentInChildren<Camera>().gameObject.AddComponent<MouseLook>().axes = MouseLook.RotationAxes.MouseY;
        }
        if (!collider)
        {
            trigger = gameObject.AddComponent<CapsuleCollider>();
        }
        else
        {
            trigger = GetComponentInChildren<CapsuleCollider>();
        }
        trigger.isTrigger = true;
        trigger.height = cc.height*1.1f;
        trigger.radius = cc.radius*1.1f;


	}
	
	// Update is called once per frame
	void Update () {
        if(lastCollider){
            lastColliderDelta = lastCollider.position - lastColliderPos;
            lastColliderPos = lastCollider.position;
            if (lastColliderDelta.magnitude > 0)
            {
                cc.Move(lastColliderDelta);
                lastColliderDelta = Vector3.zero;
            }
        }

        if (Input.GetKey(forwardKey))
        {
            moveDir += transform.forward;
        }

        if (Input.GetKey(backwardKey))
        {
            moveDir -= transform.forward;
        }
        if (Input.GetKey(rightKey))
        {
            moveDir += transform.right;
        }
        if (Input.GetKey(leftKey))
        {
            moveDir -= transform.right;
        }
        if (Input.GetKey(jump) && jumpAvailable)
        {
            Jump();
        }

        /* Move if there is somewhere to move */
        if (moveDir.magnitude > 0)
        {
            cc.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
        }
        moveDir = Vector3.zero;

        /* Gravity related stuff */
        if (gravityInc.magnitude > 0)
        {
            cc.Move(gravityInc);
        }

        falling = collisionAngle < 0;

        /* If we hit our head to the ceiling, drop down */
        if (collisionAngle == 0)
        {
            gravityInc.y = 0;
            collisionAngle = 180;
        }
        /* Actual gravity */
        if (!cc.isGrounded)
        {
            gravityInc -= gravity*Time.deltaTime;
        }
        else
        {
            gravityInc = Vector3.zero;
            jumpAvailable = true;
        }
	
	}
    public void Jump()
    {
        jumpAvailable = false;
        gravityInc = jumpHeight/10;
        lastCollider = null;
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (lastCollider != hit.transform)
        {
            lastColliderPos = hit.transform.position;
            lastCollider = hit.transform;
        }
        collisionPoint = hit.moveDirection;
        collisionAngle = Vector3.Angle(transform.up, collisionPoint);

    }
    void OnCollisionEnter(Collision c)
    {
        Debug.Log("Hit");
    }
    void OnGUI()
    {
        GUILayout.Label(collisionPoint + "");
    }
}
