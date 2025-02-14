using UnityEngine;

public class Ball : MovableObject
{
    [SerializeField] private LayerMask _wall;
    [SerializeField] private LayerMask _racket;
    [SerializeField] private Vector2 _xOffset = new Vector2(0.1f, 0f);
    [SerializeField] private Vector2 _yOffset = new Vector2(0f, 0.1f);

    private Vector2 _targetDirection;
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

        Speed += 0.05f;
        _targetDirection = _targetDirection.normalized;
    }
}
