using System.Collections;
using UnityEngine;

public class EnemySpawner : BaseSpawner
{
    protected override IEnumerator Spawn()
    {
        while (true)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(EnemySettings.Instance.LeftBound, EnemySettings.Instance.RightBound), EnemySettings.Instance.TopBound);
            GameObject newEnemy = Instantiate(_prefab, spawnPosition, Quaternion.identity);
            newEnemy.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(EnemySettings.Instance.SpawnTime);
        }
    }
}
