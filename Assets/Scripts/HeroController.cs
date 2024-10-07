using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    [SerializeField] private Collider2D groundCheck;
    private Rigidbody2D rb;
    private bool isGrounded;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        isGrounded = IsColliding(groundCheck);
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;
        
      
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (moveInput < 0)
        {
            LogCommand(CommandType.MoveLeft, moveInput);
        }
        else if (moveInput > 0)
        {
            LogCommand(CommandType.MoveRight, moveInput);
        }
        else
        {
            LogCommand(CommandType.Idle, moveInput);
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        LogCommand(CommandType.Jump, 0);
    }

    private void LogCommand(CommandType commandType, float moveInput)
    {
        CommandLogger.LogCommand(new Command(commandType, moveInput));
    }
    
    public bool IsColliding(Collider2D collider)
    {
        return collider.IsTouchingLayers();
    }
}