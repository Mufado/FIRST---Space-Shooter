using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : BaseSpawner
{
    [SerializeField]
    private GameObject _speedPrefab;
    [SerializeField]
    private GameObject _tripleLaserPrefab;
    [SerializeField]
    private GameObject _shieldPrefab;

    private Dictionary<PowerupType, GameObject> _powerupPrefabs;

    protected void Start()
    {
        _powerupPrefabs = new Dictionary<PowerupType, GameObject>
        {
            { PowerupType.Shield, _shieldPrefab },
            { PowerupType.Speed, _speedPrefab},
            { PowerupType.TripleLaser, _tripleLaserPrefab}
        };

        _player = GameObject.Find("Player").GetComponent<Player>();

        StartCoroutine(Spawn(
            spawnRange: (PowerupSettings.Instance.DefaultLeftBound, PowerupSettings.Instance.DefaultRightBound),
            topPosition: PowerupSettings.Instance.DefaultTopBound,
            spawnInterval: PowerupSettings.Instance.DefaultSpawnTime
        ));
    }

    protected override IEnumerator Spawn((float leftBound, float rightBound) spawnRange, float topPosition, float spawnInterval)
    {
        int powerupQuantity = System.Enum.GetValues(typeof(PowerupType)).Length;

        while (_player.IsAlive)
        {
            PowerupType powerupType = (PowerupType)Random.Range(0, powerupQuantity);
            _powerupPrefabs.TryGetValue(powerupType, out _prefab);

            Vector3 spawnPosition = new Vector3(Random.Range(spawnRange.leftBound, spawnRange.rightBound), topPosition);

            GameObject spawnObject = Instantiate(_prefab, spawnPosition, Quaternion.identity);
            spawnObject.transform.parent = gameObject.transform;

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
