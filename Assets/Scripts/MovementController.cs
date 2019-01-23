using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        Vector2 currentVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        Vector2 movement = new Vector2(direction * speed * Time.fixedDeltaTime, currentVelocity.y);
        gameObject.GetComponent<Rigidbody2D>().velocity = movement;
    }
}
