using UnityEngine;
using System.Collections;

public enum Direction { Left, Right, Forward, Backward }
public class Movement3D : MonoBehaviour {
    CharacterController cc;
    public float moveSpeed = 15.0f;
    public Vector3 jumpHeight = new Vector3(0, 3f, 0);
    public Vector3 gravity = new Vector3(0, 1f, 0);
    public bool controllable = true;
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backwardKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jump = KeyCode.Space;
    public bool mouseLook = true;
	public Vector2 mouseSensitivity = new Vector2 (4.0f, 4.0f);
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
	MouseLook ml_cam;
	MouseLook ml_plr;
	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
        if (!cc)
        {
            cc = gameObject.AddComponent<CharacterController>();
        }
        

        if (mouseLook && controllable)
        {
			ml_plr = gameObject.AddComponent<MouseLook>();
			ml_plr.axes = MouseLook.RotationAxes.MouseX;
			ml_plr.sensitivityX = mouseSensitivity.x;
			Camera cam = GetComponentInChildren<Camera>();
			if(cam){
				ml_cam = cam.gameObject.AddComponent<MouseLook>();
	            ml_cam.axes = MouseLook.RotationAxes.MouseY;
	            ml_cam.sensitivityY = mouseSensitivity.y;
			}
            
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
        if (controllable)
        {
            if (Input.GetKey(forwardKey))
            {
                Move(Direction.Forward);
            }

            if (Input.GetKey(backwardKey))
            {
                Move(Direction.Backward);
            }
            if (Input.GetKey(rightKey))
            {
                Move(Direction.Right);
            }
            if (Input.GetKey(leftKey))
            {
                Move(Direction.Left);
            }
            if (Input.GetKey(jump))
            {
                Jump();
            }
        }

        /* Move if there is somewhere to move */
        if (moveDir.magnitude > 0)
        {
            cc.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
        }
        moveDir = Vector3.zero;

        /* Gravity */
        if (gravityInc.magnitude > 0)
        {
            cc.Move(gravityInc);
        }

        /* Increase falling speed */
        if (!cc.isGrounded)
        {
            gravityInc -= gravity * Time.deltaTime;
        }
        else
        {
            gravityInc = Vector3.zero;
            jumpAvailable = true;
        }

        falling = collisionAngle < 0;

        /* If we hit our head to the ceiling, drop down */
        if (collisionAngle == 0)
        {
            gravityInc.y = 0;
            collisionAngle = 180;
        }
	
	}
    public void Move(Direction dir)
    {
        switch (dir)
        {
            case Direction.Left:
                moveDir -= transform.right;
                break;
            case Direction.Right:
                moveDir += transform.right;
                break;
            case Direction.Forward:
                moveDir += transform.forward;
                break;
            case Direction.Backward:
                moveDir -= transform.forward;
                break;
        }
    }
    public void Jump()
    {
        if (jumpAvailable)
		{
			Debug.Log ("Jump!");
            jumpAvailable = false;
            gravityInc = jumpHeight / 10;
            lastCollider = null;
        }
    }
    public void Turn(Vector3 lookRotation)
    {
        transform.rotation = Quaternion.LookRotation(lookRotation);
        Debug.DrawRay(transform.position, lookRotation, Color.red);
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
        //GUILayout.Label(collisionPoint + "");
    }
}
