using System.Collections;
using UnityEngine;

public abstract class BaseSpawner : MonoBehaviour
{
    // Needs to know if player dies to stop spawning
    protected Player _player;
    [SerializeField]
    protected GameObject _prefab;

    protected virtual IEnumerator Spawn((float leftBound, float rightBound) spawnRange, float topPosition, float spawnInterval)
    {
        while (_player.IsAlive)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(spawnRange.leftBound, spawnRange.rightBound), topPosition);
            GameObject spawnObject = Instantiate(_prefab, spawnPosition, Quaternion.identity);
            spawnObject.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
