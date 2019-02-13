using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _agressionRadius = 4;
    [SerializeField] private float _attackRadius = 2;
    [SerializeField] private float _movespeed = 300;
    [SerializeField] private float _attackCooldown = 2;
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _homePosition;
    [SerializeField] private Transform _bulletStartPosition;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _enemyDamage = 10;
    [SerializeField] private float _bulletSpeed = 400;
    [SerializeField] private float _bulletLifetime = 3;


    private bool _isAttackOnCooldown = false;
    private float _playerDistance;
    private bool _isPlayerOnRight = false;
    private bool _facingRight = false;
    private Rigidbody2D _rg;

    private void Start()
    {
        _rg = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        getPlayerInfo();
        enemyRotationContoller();

        if (ShouldAttack())
        {
            Attack();
        } else if (ShouldEngage())
        {
            Move(_player.transform);
        } else if (!IsHome())
        {
            Move(_homePosition);
        }
    }

    void getPlayerInfo()
    {
        _playerDistance = Mathf.Abs(transform.position.x - _player.transform.position.x);
        _isPlayerOnRight = transform.position.x < _player.transform.position.x;
    }

    void enemyRotationContoller ()
    {
        bool movingRight = gameObject.GetComponent<Rigidbody2D>().velocity.x > 0;
        if ((_isPlayerOnRight && !_facingRight) || (!ShouldEngage() && movingRight))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            _facingRight = true;
        } else if (!_isPlayerOnRight && _facingRight)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            _facingRight = false;
        }
    }

    void Move(Transform targetPosition)
    {
        float moveSign = transform.position.x < targetPosition.position.x ? 1 : -1;
        Vector2 movement = new Vector2(moveSign * _movespeed * Time.fixedDeltaTime, _rg.velocity.y);
        _rg.velocity = movement;
    }

    bool ShouldEngage()
    {
        return _playerDistance < _agressionRadius;
    }

    bool ShouldAttack()
    {
        return (_playerDistance < _attackRadius);
    }

    bool IsHome()
    {
        float homeDistance = Mathf.Abs(transform.position.x - _homePosition.position.x);
        return homeDistance < 0.5;
    }

    void Attack()
    {
        if (!_isAttackOnCooldown)
        {
            Bullet bullet = Instantiate(_bullet);
            bullet.startPosition = _bulletStartPosition.position;
            bullet._hitLayer = _playerLayer;
            bullet._damage = _enemyDamage;
            bullet._speed = _bulletSpeed;
            bullet._lifetime = _bulletLifetime;

            bullet.fireRight = _facingRight;

            _isAttackOnCooldown = true;
            Invoke("ResetCooldown", _attackCooldown);
        }
    }

    void ResetCooldown()
    {
        _isAttackOnCooldown = false;
    }
}
