using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Enemy enemyToSpawn;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "Player")
        {
            Enemy enemy = Instantiate(enemyToSpawn);
            enemy.transform.position = spawnPosition.position;
        }
    }
}
