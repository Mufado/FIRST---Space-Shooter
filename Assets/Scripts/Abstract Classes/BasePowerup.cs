using System;
using UnityEngine;

public class BasePowerup : MonoBehaviour
{
    protected GameObject _prefab;

    protected virtual void Update()
    {
        Moves();

        LimitMoves();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player": ActivatePowerup(); break;
        }
    }

    protected virtual void ActivatePowerup()
    {
        Debug.LogError("Powerup activation not implemented.");
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
