using UnityEngine;

public class Laser : BaseGun
{
    void Start() 
    {
        damage = LaserSettings.Instance.Damage;
        speed = LaserSettings.Instance.Speed;
    }

    void Update()
    {
        Moves();

        LimitMoves();
    }

    protected override void LimitMoves()
    {
        if (transform.position.y >= LaserSettings.Instance.Bound)
        {
            Destroy(gameObject);
        }
    }

    protected override void Moves()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
