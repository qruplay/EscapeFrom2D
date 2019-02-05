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
    [HideInInspector] public bool facingRight = true;


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

        if (direction < 0 && facingRight)
        {
            Flip();
        } else if (direction > 0 && !facingRight)
        {
            Flip();
        }

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

    private void Flip ()
    {
        if (facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            facingRight = false;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            facingRight = true;
        }
    }
}
