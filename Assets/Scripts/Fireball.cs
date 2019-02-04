using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private float _lifetime;
    [HideInInspector] public Vector3 startPosition;
    private Vector2 _direction;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = startPosition;
        _direction = Vector2.right;
        Destroy(gameObject, _lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Time.fixedDeltaTime * _direction * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Health>().takeDamage(_damage);
        }

        Destroy(gameObject);
    }
}
