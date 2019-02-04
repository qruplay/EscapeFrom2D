using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private Enemy _enemyToSpawn;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Enemy enemy = Instantiate(_enemyToSpawn);
            enemy.transform.position = _spawnPosition.position;
        }
    }
}
