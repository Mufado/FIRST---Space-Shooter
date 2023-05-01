using System;
using UnityEngine;

public class Player : BaseShooterSpaceship
{
    [SerializeField]
    private GameObject _shield;
    private bool _isShieldActive;
    private UIManager _uiManager;
    private int _score;
    private (float, float) _movesInput
    {
        get
        {
            return (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
    }
    public bool IsShieldActive
    {
        get { return _isShieldActive; }

        set
        {
            _shield.SetActive(value);
            _isShieldActive = value;
        }
    }

    void Start()
    {
        lives = PlayerSettings.Instance.Lives;
        speed = PlayerSettings.Instance.Speed;
        fireRate = PlayerSettings.Instance.FireRate;
        collisionDamage = PlayerSettings.Instance.CollisionDamage;

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
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
            case "Powerup": CollideWithPowerup(other); break;
            default: break;
        }
    }

    private void CollideWithPowerup(Collider2D other)
    {
        Destroy(other.gameObject);

        BasePowerup powerup = other.GetComponent<BasePowerup>();

        powerup.ApplyPowerup(this);
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

    public override void TakeDamage(int damage)
    {
        if (IsShieldActive)
        {
            IsShieldActive = false;
            return;
        }

        base.TakeDamage(damage);
    }

    public void UpdateScore(int scoreValue)
    {
        _score += scoreValue;

        _uiManager.UpdateScoreText(_score);
    }
}
