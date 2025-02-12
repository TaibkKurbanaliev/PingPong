using UnityEngine;


public class Enemy : MovableObject
{
    [SerializeField] private float _maxYPos = 8;

    private Vector2 _targetDirection = Vector2.up;

    protected override void Move()
    {
        var currentPos = new Vector2(transform.position.x, transform.position.y);

        if (currentPos.y > _maxYPos)
        {
            _targetDirection *= Vector2.down;
        }
        else if (currentPos.y < -_maxYPos)
        {
            _targetDirection = Vector2.up;
        }

        Rb.MovePosition(currentPos + _targetDirection * Speed * Time.fixedDeltaTime);
    }
}
