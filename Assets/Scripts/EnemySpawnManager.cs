using System.Collections;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(EnemySettings.Instance.LeftBound, EnemySettings.Instance.RightBound), EnemySettings.Instance.TopBound);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(EnemySettings.Instance.SpawnTime);
        }
    }
}
