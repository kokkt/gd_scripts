using UnityEngine;
using System.Collections;

public class Movement3D_rigidbody : MonoBehaviour
{
    public float acceleration = 5.0f;
    public float maxSpeed = 10.0f;
    public Vector3 jumpHeight = new Vector3(0, 10f, 0);
    public Vector3 gravity = new Vector3(0, 1f, 0);
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode backwardKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jump = KeyCode.Space;
    public bool mouseLook = true;
    public Vector3 gravityInc = new Vector3();
    public float slopeThreshold = 0.2f;
    Transform lastCollider;
    Vector3 lastColliderPos;
    Vector3 lastColliderDelta = Vector3.zero;
    Vector3 moveDir = new Vector3();
    bool jumpAvailable = true;
    ContactPoint[] collisionPoints;
    Vector3 collisionAngle;
    bool isGrounded = false;
    Ray slopeRay = new Ray();
    Vector3 slopeVector = new Vector3();
    RaycastHit slopeHit;
    // Use this for initialization
    void Start()
    {
        if (!rigidbody)
        {
            gameObject.AddComponent<Rigidbody>();
        }
        rigidbody.mass = 20.0f;
        rigidbody.drag = 5.0f;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        

        if (mouseLook)
        {
            gameObject.AddComponent<MouseLook>().axes = MouseLook.RotationAxes.MouseX;
            GameObject.FindWithTag("MainCamera").AddComponent<MouseLook>().axes = MouseLook.RotationAxes.MouseY;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lastCollider)
        {
            lastColliderDelta = lastCollider.position - lastColliderPos;
            lastColliderPos = lastCollider.position;
            if (lastColliderDelta.magnitude > 0)
            {
                transform.Translate(lastColliderDelta, Space.World);
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

        slopeVector = collider.bounds.center;
        slopeVector.y = collider.bounds.min.y + slopeThreshold;
        slopeRay.origin = slopeVector;
        slopeRay.direction = moveDir.normalized;
        /* Move if there is somewhere to move */
        if (moveDir.magnitude > 0 && !collider.Raycast(slopeRay, out slopeHit, 1.0f))
        {
            transform.Translate(moveDir.normalized * acceleration * Time.deltaTime, Space.World);
        }
        moveDir = Vector3.zero;

        /* Gravity related stuff */
        if (gravityInc.magnitude > 0)
        {
            transform.Translate(gravityInc, Space.World);        
        }
        

        /* Actual gravity */
        if (!isGrounded && !(lastCollider && collider.bounds.Intersects(lastCollider.collider.bounds)))
        {            
            gravityInc -= gravity * Time.deltaTime;
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
        lastCollider = null;
        rigidbody.AddForce(jumpHeight, ForceMode.VelocityChange);
    }
    void OnCollisionEnter(Collision hit)
    {
        collisionPoints = hit.contacts;
        collisionAngle =  transform.position-collisionPoints[0].point;
        isGrounded = false;
        foreach (ContactPoint c in hit.contacts)
        {            
            if (c.point.y > collider.bounds.min.y - slopeThreshold)
            {
                isGrounded = true;
                if (lastCollider != hit.transform)
                {
                    lastColliderPos = hit.transform.position;
                    lastCollider = hit.transform;
                    Debug.Log("Last collider now: " + lastCollider);
                }
            }
        }
        jumpAvailable = true;

    }
    void OnCollisionExit(Collision hit)
    {
        isGrounded = false;
        lastCollider = null;
    }
    void OnGUI()
    {
        GUILayout.Label(collisionAngle + "");
        GUILayout.Label(isGrounded+"");
    }
    void OnDrawGizmos(){
    
    }
}
