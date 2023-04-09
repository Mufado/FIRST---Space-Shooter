using System.Collections;
using UnityEngine;

public abstract class BaseSpawner : MonoBehaviour
{
    [SerializeField]
    protected GameObject _prefab;

    protected virtual void Start()
    {
        StartCoroutine(Spawn());
    }

    protected abstract IEnumerator Spawn();
}
