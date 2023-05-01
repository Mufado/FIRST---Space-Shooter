using UnityEngine;

public class Enemy : BaseSpaceship
{
    private int _scoreValue = EnemySettings.Instance.ScoreValue;
    private Player _player;

    void Start()
    {
        lives = EnemySettings.Instance.Lives;
        speed = EnemySettings.Instance.Speed;
        collisionDamage = EnemySettings.Instance.CollisionDamage;

        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    void Update()
    {
        Moves(Vector3.down);

        LimitMoves();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Player":
                CollideWithPlayer(); break;
            case "Gun":
                CollideWithShot(other); break;
            default: break;
        }
    }

    protected override void LimitMoves()
    {
        if (transform.position.y <= EnemySettings.Instance.BottomBound)
        {
            transform.position = new Vector3(Random.Range(EnemySettings.Instance.LeftBound, EnemySettings.Instance.RightBound), EnemySettings.Instance.TopBound);
        }
    }

    private void CollideWithPlayer()
    {
        TakeDamage(_player.collisionDamage);
        _player.TakeDamage(collisionDamage);
    }

    private void CollideWithShot(Collider2D other)
    {
        Destroy(other.gameObject);
        BaseGun gun = other.GetComponent<BaseGun>();
        TakeDamage(gun.damage);
    }

    public override void TakeDamage(int damage)
    {
        lives -= damage;

        if (!IsAlive)
        {
            Destroy(gameObject);

            _player.UpdateScore(_scoreValue);
        }
    }
}
