using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private KeyCode up;
    [SerializeField]
    private KeyCode down;
    [SerializeField]
    private PlayerStatus status;
    [SerializeField]
    private Rigidbody2D rb;

    public bool CanAct { get; set; }

    private void Update()
    {
        if (CanAct)
        {
            HandleMoving();
        }
    }

    private void HandleMoving()
    {
        Vector2 movementVector = Vector2.zero;
        if (Input.GetKey(up))
        {
            movementVector += Vector2.up;
        }
        if (Input.GetKey(down))
        {
            movementVector += Vector2.down;
        }
        rb.velocity = movementVector * status.MovementSpeed;
    }
}
