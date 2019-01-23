using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float lifetime;
    [HideInInspector] public Vector3 startPosition;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = startPosition;
        direction = Vector2.right;
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Time.deltaTime * direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Health>().takeDamage(damage);
        }

        Destroy(gameObject);
    }
}
