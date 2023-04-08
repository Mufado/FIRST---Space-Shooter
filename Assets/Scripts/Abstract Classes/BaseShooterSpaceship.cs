using UnityEngine;

public abstract class BaseShooterSpaceship : BaseSpaceship
{
    public float fireRate;
    protected float _lastShot;
    [SerializeField]
    protected GameObject _ammoPrefab;

    protected bool GunOnCooldown
    {
        get
        {
            return Time.time < fireRate + _lastShot ? true : false;
        }
    }

    protected abstract void Shoot();
}
