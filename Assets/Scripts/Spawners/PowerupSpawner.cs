using System.Collections;
using UnityEngine;

public class PowerupSpawner : BaseSpawner
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
            Vector3 spawnPosition = new Vector3(Random.Range(PowerupSettings.Instance.DefaultLeftBound, PowerupSettings.Instance.DefaultRightBound), PowerupSettings.Instance.DefaultTopBound);
            GameObject newPowerup = Instantiate(_prefab, spawnPosition, Quaternion.identity);
            newPowerup.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(Random.Range(15f, 20f));
        }
    }
}
