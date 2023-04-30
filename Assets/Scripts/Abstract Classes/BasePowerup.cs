using UnityEngine;

public abstract class BasePowerup : MonoBehaviour
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

    protected void LimitMoves()
    {
        if (transform.position.y <= PowerupSettings.Instance.DefaultBottomBound)
        {
            Destroy(gameObject);
        }
    }

    public abstract void ApplyPowerup(Player player);
}
