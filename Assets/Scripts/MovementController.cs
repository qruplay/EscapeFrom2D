using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;
    //Player RG
    private Rigidbody2D rg;
    private bool isOnGround = false;
    private bool isSecondJumpAvailable = false;


    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Player movement
        float direction = Input.GetAxis("Horizontal");
        Vector2 currentVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        Vector2 movement = new Vector2(direction * _speed * Time.fixedDeltaTime, currentVelocity.y);
        rg.velocity = movement;

        JumpController();
    }

    private void JumpController()
    {
        RaycastHit2D groundCheck = Physics2D.Raycast(transform.position, Vector2.down, 1, _groundLayer);

        isOnGround = System.Convert.ToBoolean(groundCheck.collider);

        //Player jump
        bool jump = Input.GetButtonDown("Jump");

        if (jump)
        {
            if (isOnGround)
            {
                Jump();
                isSecondJumpAvailable = true;
            }
            else if (isSecondJumpAvailable)
            {
                Jump();
                isSecondJumpAvailable = false;
            }
        }
    }

    private void Jump ()
    {
        rg.AddForce(Vector2.up * _jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ground collision");
        if (collision.gameObject.tag=="Ground")
        {
            isOnGround = true;
            isSecondJumpAvailable = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isOnGround = false;
        }
    }
}
