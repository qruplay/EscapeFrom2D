using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float _explodeTime = 2;
    [SerializeField] private float _explodeForce = 100;
    [SerializeField] private float _explodeRadius = 5;
    [SerializeField] private float _damage = 50;
    [SerializeField] private float _triggerRadius = 1;
    [SerializeField] private LayerMask _enemyLayer;

    void Update()
    {
        Collider2D triggerEnemyColider = Physics2D.OverlapCircle(transform.position, _triggerRadius, _enemyLayer);

        if (triggerEnemyColider)
        {
            Invoke("Explode", _explodeTime);
        }
    }

    private void Explode ()
    {
        Collider2D[] enemiesColider = Physics2D.OverlapCircleAll(gameObject.transform.position, _explodeRadius, _enemyLayer);
        foreach (Collider2D enemyColider in enemiesColider) {
            GameObject enemyGO = enemyColider.gameObject;

            enemyGO.GetComponent<Health>().takeDamage(_damage);
            enemyGO.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _explodeForce, ForceMode2D.Impulse);
        }

        Destroy(gameObject);
    }
}
