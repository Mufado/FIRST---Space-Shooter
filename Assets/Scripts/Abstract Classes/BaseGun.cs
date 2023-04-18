using UnityEngine;

public abstract class BaseGun : MonoBehaviour
{
    public int damage;
    public float speed;

    protected virtual void Moves()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    protected virtual void LimitMoves()
    {
        if (transform.position.y >= GameSettings.Instance.DefaultBulletBound)
        {
            Destroy(gameObject);
        }
    }
}
