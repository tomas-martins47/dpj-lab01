using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    [Header("Movimento")]
    public float moveSpeed = 5f;

    [Header("Salto")]
    public float jumpForce = 7f;
    public Transform groundCheck;           
    public float groundCheckRadius = 0.12f; 
    public LayerMask groundLayer;           

    [Header("Opcional")]
    public bool allowDoubleJump = false;

    private Rigidbody2D rb;
    private float horizontalInput;
    public bool isGrounded;
    private bool canDoubleJump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (groundCheck == null)
        {
            Debug.LogWarning("groundCheck n�o atribu�do em " + gameObject.name + ". Criar child vazio posicionado nos p�s e arrastar aqui.");
        }
    }
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (groundCheck != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        }

        if (isGrounded)
        {
            canDoubleJump = allowDoubleJump;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                Jump();
            }
            else if (allowDoubleJump && canDoubleJump)
            {
                Jump();
                canDoubleJump = false;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 vel = rb.linearVelocity;
        vel.x = horizontalInput * moveSpeed;
        rb.linearVelocity = vel;
    }

    private void Jump()
    {
        Vector2 vel = rb.linearVelocity;
        vel.y = 0f;
        rb.linearVelocity = vel;

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}