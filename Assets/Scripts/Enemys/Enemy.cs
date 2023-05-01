using UnityEngine;

public class Enemy : BaseSpaceship
{
    private int _scoreValue = EnemySettings.Instance.ScoreValue;

    void Start()
    {
        lives = EnemySettings.Instance.Lives;
        speed = EnemySettings.Instance.Speed;
        collisionDamage = EnemySettings.Instance.CollisionDamage;
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
                CollideWithPlayer(other); break;
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

    private void CollideWithPlayer(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        TakeDamage(player.collisionDamage);
        player.TakeDamage(collisionDamage);
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

            Player player = GameObject.Find("Player").GetComponent<Player>();

            player.UpdateScore(_scoreValue);
        }
    }
}
