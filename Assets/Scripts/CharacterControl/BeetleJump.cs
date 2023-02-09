using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BeetleJump : MonoBehaviour
{
    private Rigidbody rbody;
    public float thrust = 1.0f;

    public float jumpableGroundNormalMaxAngle = 45f;
    public bool closeToJumpableGround;

    private int groundContactCount = 0;

    public bool IsGrounded
    {
        get
        {
            return groundContactCount > 0;
        }
    }
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();

        if (rbody == null)
            Debug.Log("Rigid body could not be found");
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        bool isGrounded = IsGrounded || CharacterCommon.CheckGroundNear(this.transform.position, jumpableGroundNormalMaxAngle, 0.85f, 0f, out closeToJumpableGround);

        time += Time.deltaTime;

        float next = Random.Range(2, 5);


        if (isGrounded && time >= next)
        {
            rbody.AddForce(Random.Range(0.0f,5.0f), Random.Range(0.0f, 5.0f), Random.Range(0.0f, 5.0f), ForceMode.Impulse);
            time = 0.0f;
        }

    }
}
