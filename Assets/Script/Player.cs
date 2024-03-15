using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float JumpSpeed;
    private Rigidbody2D rb;

    public Transform GroundCheck;
    public float CheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;

    // Extra jump
    public int maxJumpValue;
    int maxJump;

    // Start is called before the first frame update
    private void Start()
    {
        maxJump = maxJumpValue;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, CheckRadius, whatIsGround);
        if(Input.GetMouseButtonDown(0) && maxJump > 0)
        {
            maxJump--;
            Jump();
        }
        else if(Input.GetMouseButtonDown(0) && maxJump == 0 && isGrounded) {
            Jump();
        }

        if(isGrounded)
        {
            maxJump = maxJumpValue;
        }
    }

    void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(0, JumpSpeed));
    }
}
