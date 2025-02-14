using UnityEngine;


public class Enemy : MovableObject
{
    [SerializeField] private float _maxYPos = 8;
    [SerializeField] private Ball _ball; 

    private Vector2 _targetDirection = Vector2.up;

    protected override void Move()
    {
        var currentPos = new Vector2(transform.position.x, transform.position.y);

        _targetDirection = new Vector2(0f, _ball.transform.position.y - currentPos.y).normalized;
        Debug.Log(_targetDirection);

        Rb.MovePosition(currentPos + _targetDirection * Speed * Time.fixedDeltaTime);
    }
}
