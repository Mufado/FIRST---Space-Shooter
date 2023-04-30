using System.Collections;
using UnityEngine;

public class PowerupSpawner : BaseSpawner
{
    protected void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        StartCoroutine(Spawn(
            spawnRange: (PowerupSettings.Instance.DefaultLeftBound, PowerupSettings.Instance.DefaultRightBound),
            topPosition: PowerupSettings.Instance.DefaultTopBound,
            spawnInterval: PowerupSettings.Instance.DefaultSpawnTime
        ));
    }
}
