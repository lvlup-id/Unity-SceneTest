using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform groundCheck;
    public string playerName;
    public int health, damage;
    public float speed = 5f, jumpHeight = 5f;
    [SerializeField] bool isGrounded = true;
    Rigidbody2D rb;
    Vector2 movement;
    RaycastHit2D visionHit;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {

    }

    private void Update()
    {

        if (isGrounded)
        {
            movement.x = Input.GetAxis("Horizontal");

            if (Input.GetKeyUp(KeyCode.Space))
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    private void FixedUpdate()
    {
        visionHit = Physics2D.CircleCast(groundCheck.position, 1f, transform.right, 3f, 1 << LayerMask.NameToLayer("Enemy"));

        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, -Vector2.up, 0.2f);
        if (hit)
        {
            if (hit.collider.tag == "Ground")
                isGrounded = true;
            else
                isGrounded = false;
        }
        else isGrounded = false;

        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
    }

    public void AddForce()
    {
        rb.AddForce(transform.up * 10f, ForceMode2D.Impulse);
    }

    private void OnDrawGizmos()
    {
        // Gizmos.color = Color.blue;

        // Debug.DrawRay(transform.position, transform.right * 3f, Color.red, 0.2f);
        // if (visionHit.collider != null && visionHit.collider.tag == "Enemy")
        //     Gizmos.DrawWireSphere(visionHit.point, 1f);

    }
}
