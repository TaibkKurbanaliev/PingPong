using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MovableObject
{

    protected override void Move()
    {
        var input = Input.GetAxis("Vertical");
        var currentPos = new Vector2(transform.position.x, transform.position.y);
        Rb.MovePosition(currentPos + Vector2.up * Speed * input * Time.fixedDeltaTime);
        
    }
}
