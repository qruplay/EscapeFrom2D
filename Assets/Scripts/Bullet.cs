using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _speed;
    public float _damage;
    public float _lifetime;
    public LayerMask _hitLayer;
    [HideInInspector] public Vector3 startPosition;
    [HideInInspector] public bool fireRight;
    protected Vector2 _direction;
    [SerializeField] private GameObject _explosionSound;

    // Start is called before the first frame update
    protected void Start()
    {
        gameObject.transform.position = startPosition;

        if (fireRight)
        {
            _direction = Vector2.right;
        }
        else
        {
            _direction = Vector2.left;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        Destroy(gameObject, _lifetime);
    }

    // Update is called once per frame
    protected void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Time.fixedDeltaTime * _direction * _speed;
    }


    //Works only with single layer in LayerMask
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == Mathf.Log(_hitLayer.value, 2))
        {
            collision.gameObject.GetComponent<Health>().takeDamage(_damage);
        }

        Instantiate(_explosionSound, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
