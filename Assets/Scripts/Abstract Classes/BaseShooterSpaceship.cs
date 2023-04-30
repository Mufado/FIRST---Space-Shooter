using UnityEngine;

public abstract class BaseShooterSpaceship : BaseSpaceship
{
    public float fireRate;
    public GameObject ammoPrefab;
    protected float _lastShot;

    protected bool GunOnCooldown
    {
        get
        {
            return Time.time < fireRate + _lastShot ? true : false;
        }
    }

    protected abstract void Shoot();
}
