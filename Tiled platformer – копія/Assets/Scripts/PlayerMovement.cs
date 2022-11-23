// ���� ���������� ����� �����

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //���� 
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;

    //���������� �������, �� ��� ����� ����� ��������
    [SerializeField] private LayerMask jumpableGround;

    // ���� �������
    [SerializeField] private AudioSource jumpSoundEffects;

    private float dirX=0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private AudioSource pinaplesAudioSource;

    //����� ��� �������� �� ����� �����������
    private bool boosting;
    // ������, ���� ��� �������� ��� �����������
    private float boostTimer;

    // ������ �������� ����� ���������
    private enum MovementState
    {
            idle,
            running,
            jumping,
            falling
    }

    private void Start()
    {
        // ����������� ������
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        boosting = false;
        boostTimer = 0;
    }

    private void Update()
    {
        //���������� �������� ���� �� ����������
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity= new Vector2 (dirX* moveSpeed, rb.velocity.y);

        // ��� ��������� Jump ������ ������ Jump
        // �������� �����, �� ��'��� �� ��������� �������
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        // ��������� �����������
        if (boosting)
        {
            // ���� �������� ����
            moveSpeed = 10f;
            // ����� �������
            boostTimer+= Time.deltaTime;
            // ������ ���� 7 ������
            if (boostTimer > 7f)
            {
                //���������� �� ���������� �����������
                moveSpeed = 7f;
                boostTimer= 0;
                boosting = false;
            }
        }
        // ������ ������ ��� ��������� ���������
        UpdateAnimationState();
    }

    // ����� ��� ��������� ����������� ��� ������� � ��'����� � ����� speed_col
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("speed_col"))
        {
            pinaplesAudioSource.Play();
            Destroy(collision.gameObject);
            boosting = true;
        }
    }

    // ����� ��� �������
    public void Jump()
    {
            jumpSoundEffects.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);      
            UpdateAnimationState();
    } 

    // ����� ��������� ���������
    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        if(rb.velocity.y > .1f)
        {
            state =MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround); 
    }
}
