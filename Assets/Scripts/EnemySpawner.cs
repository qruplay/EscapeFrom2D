using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private EnemyAI _enemyToSpawn;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            EnemyAI enemy = Instantiate(_enemyToSpawn);
            enemy.transform.position = _spawnPosition.position;
        }
    }
}
