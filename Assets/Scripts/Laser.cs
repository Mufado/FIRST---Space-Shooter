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
}
