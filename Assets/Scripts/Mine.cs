using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float explodeTime = 2;
    [SerializeField] private float explodeForce = 100;
    [SerializeField] private float explodeRadius = 5;
    [SerializeField] private float damage = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Explode ()
    {
        Collider2D[] enemiesColider = Physics2D.OverlapCircleAll(gameObject.transform.position, explodeRadius);
        foreach (Collider2D enemyColider in enemiesColider) {
            GameObject enemyGO = enemyColider.gameObject;
            bool isEnemy = enemyGO.GetComponent<Enemy>();
            if (isEnemy)
            {
                enemyGO.GetComponent<Health>().takeDamage(damage);
                enemyGO.GetComponent<Rigidbody2D>().AddForce(Vector2.up * explodeForce, ForceMode2D.Impulse);
            }
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Invoke("Explode", explodeTime);
        }
    }
}
