using System.Collections;
using UnityEngine;

public class EnemySpawner : BaseSpawner
{
    // Needs to know if player dies to stop spawning
    private Player _player;

    protected override void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        StartCoroutine(Spawn());
    }

    protected override IEnumerator Spawn()
    {
        while (_player.IsAlive)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(EnemySettings.Instance.LeftBound, EnemySettings.Instance.RightBound), EnemySettings.Instance.TopBound);
            GameObject newEnemy = Instantiate(_prefab, spawnPosition, Quaternion.identity);
            newEnemy.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(EnemySettings.Instance.SpawnTime);
        }
    }
}
