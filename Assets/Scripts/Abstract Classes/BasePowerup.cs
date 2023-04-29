using System;
using UnityEngine;

public class BasePowerup : MonoBehaviour
{
    protected virtual void Update()
    {
        Moves();

        LimitMoves();
    }

    protected virtual void Moves()
    {
        transform.Translate(Vector3.down * PowerupSettings.Instance.DefaultSpeed * Time.deltaTime);
    }

    private void LimitMoves()
    {
        if (transform.position.y <= PowerupSettings.Instance.DefaultBound)
        {
            Destroy(gameObject);
        }
    }
}
