using UnityEngine;
using UnityEngine.Events;

public class Ball : MovableObject
{
    [SerializeField] private LayerMask _wall;
    [SerializeField] private LayerMask _racket;
    [SerializeField] private LayerMask _playerWall;
    [SerializeField] private LayerMask _enemyWall;
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Vector2 _xOffset = new Vector2(0.1f, 0f);
    [SerializeField] private Vector2 _yOffset = new Vector2(0f, 0.1f);
    [SerializeField] private AudioSource _audio;

    private Vector2 _targetDirection;
    private float _speedMultiplier = 0.05f;

    public UnityAction<bool> Goaled;

    public void Init(float speed, float speedMultiplier)
    {
        Speed = speed;
        _speedMultiplier = speedMultiplier;
    }

    private void Start()
    {
        _targetDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
    }

    protected override void Move()
    {
        var currentPos = new Vector2(transform.position.x, transform.position.y);
        Rb.MovePosition(currentPos + _targetDirection * Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((1 << collision.gameObject.layer & _wall) != 0)
        {
            
            _targetDirection = Vector2.Reflect(_targetDirection, Vector2.down * Mathf.Sign(Rb.linearVelocityY)) + _yOffset * Mathf.Sign(Rb.linearVelocityY);
        }
        else
        {
            _targetDirection = Vector2.Reflect(_targetDirection, Vector2.right * Mathf.Sign(Rb.linearVelocityX)) + _xOffset * Mathf.Sign(Rb.linearVelocityX);
        }

        Speed += _speedMultiplier;
        _targetDirection = _targetDirection.normalized;
        _audio.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & _enemyWall) != 0)
        {
            Goaled.Invoke(false);

            _enemy.AddScore();
        }
        else if((1 << collision.gameObject.layer & _playerWall) != 0)
        {
            Goaled.Invoke(true);

            _player.AddScore();
        }

        transform.position = Vector2.zero;
        _targetDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
    }
}
