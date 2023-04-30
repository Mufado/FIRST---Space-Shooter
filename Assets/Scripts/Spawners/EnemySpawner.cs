using System.Collections;
using UnityEngine;

public class EnemySpawner : BaseSpawner
{
    protected void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        StartCoroutine(Spawn(
            spawnRange: (EnemySettings.Instance.LeftBound, EnemySettings.Instance.RightBound),
            topPosition: EnemySettings.Instance.TopBound,
            spawnInterval: EnemySettings.Instance.SpawnTime
        ));
    }
}
