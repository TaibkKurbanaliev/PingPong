using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class MovableObject : MonoBehaviour
{
    [SerializeField] protected float Speed = 10f;

    protected Rigidbody2D Rb;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    abstract protected void Move();
}
