using UnityEngine;

public abstract class BaseGun : MonoBehaviour
{
    public int damage;
    public float speed;

    protected abstract void Moves();
    protected abstract void LimitMoves();
}
