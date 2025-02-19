using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class MovableObject : MonoBehaviour
{
    [SerializeField] protected float Speed = 10f;

    public UnityAction<string> Winned;
    public int Score { get; private set; } = 0;

    protected Rigidbody2D Rb;
    abstract protected void Move();

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void AddScore()
    {
        Score++;
        int winScore = 2;

        if (Score == winScore)
        {
            if (TryGetComponent(out Player _))
            {
                Winned?.Invoke(typeof(Player).Name);
            }
            else
            {
                Winned?.Invoke(typeof(Enemy).Name);
            }
        }
    }

}
