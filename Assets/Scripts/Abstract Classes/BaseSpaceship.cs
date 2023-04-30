using UnityEngine;

public abstract class BaseSpaceship : MonoBehaviour
{
    public int lives;
    public float speed;
    public int collisionDamage;

    public bool IsAlive {
        get
        {
            return lives > GameSettings.Instance.DeathThreshold;
        }
    }

    protected void Moves((float horizontal, float vertical) direction)
    {
        transform.Translate(new Vector3(direction.horizontal, direction.vertical) * speed * Time.deltaTime);
    }

    protected void Moves(Vector3 direction)
    {
        transform.Translate(new Vector3(direction.x, direction.y) * speed * Time.deltaTime);
    }

    protected abstract void LimitMoves();

    public virtual void TakeDamage(int damage)
    {
        lives -= damage;

        if (!IsAlive)
        {
            Destroy(gameObject);
        }
    }
}
