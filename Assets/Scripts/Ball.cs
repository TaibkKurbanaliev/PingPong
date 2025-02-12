using UnityEngine;

public class Ball : MovableObject
{
    private Vector2 _targetDirection;

    private void Start()
    {
        _targetDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
    }

    protected override void Move()
    {
        var currentPos = new Vector2(transform.position.x, transform.position.y);
        Rb.MovePosition(currentPos * _targetDirection * Speed * Time.deltaTime);
    }
}
