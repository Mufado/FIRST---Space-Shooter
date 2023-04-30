using UnityEngine;

public class Player : BaseShooterSpaceship
{
    private (float, float) _movesInput
    {
        get
        {
            return (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }

    void Start()
    {
        lives = PlayerSettings.Instance.Lives;
        speed = PlayerSettings.Instance.Speed;
        fireRate = PlayerSettings.Instance.FireRate;
        collisionDamage = PlayerSettings.Instance.CollisionDamage;
    }

    void Update()
    {
        Moves(_movesInput);

        LimitMoves();

        if (Input.GetKey(KeyCode.Space) && !GunOnCooldown)
        {
            Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "ChangeAmmoPowerup": CollideWithPowerup(other); break;
            default: break;
        }
    }

    protected override void LimitMoves()
    {
        float horizontalClamp = Mathf.Clamp(transform.position.x, PlayerSettings.Instance.LeftBound, PlayerSettings.Instance.RightBound);
        float verticalClamp = Mathf.Clamp(transform.position.y, PlayerSettings.Instance.BottomBound, PlayerSettings.Instance.TopBound);

        transform.position = new Vector3(horizontalClamp, verticalClamp);
    }

    protected override void Shoot()
    {
        _lastShot = Time.time;

        Vector3 laserPosition = new Vector3(transform.position.x, transform.position.y + PlayerSettings.Instance.MuzzlePosition);

        Instantiate(ammoPrefab, laserPosition, Quaternion.identity);
    }

    private void CollideWithPowerup(Collider2D other)
    {
        Destroy(other.gameObject);

        BasePowerup powerup = other.GetComponent<BasePowerup>();

        powerup.ApplyPowerup(this);
    }
}
