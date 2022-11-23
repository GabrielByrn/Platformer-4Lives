// Клас реалізайції рухів героя

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Поля 
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D coll;

    //Визначення поверхні, на якій герой зможе стрибати
    [SerializeField] private LayerMask jumpableGround;

    // Звук стрибка
    [SerializeField] private AudioSource jumpSoundEffects;

    private float dirX=0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private AudioSource pinaplesAudioSource;

    //Змінна для значення чи герой прискорений
    private bool boosting;
    // Таймер, який час пресонаж вже прискорений
    private float boostTimer;

    // Перелік можливих станів персонажа
    private enum MovementState
    {
            idle,
            running,
            jumping,
            falling
    }

    private void Start()
    {
        // Ініціалізація змінних
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        boosting = false;
        boostTimer = 0;
    }

    private void Update()
    {
        //Записується значення руху по горизонталі
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity= new Vector2 (dirX* moveSpeed, rb.velocity.y);

        // ПРи натисканні Jump виклик методу Jump
        // Перевірка умови, чи об'єкт на правильній поверхні
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        // Реалізація прискорення
        if (boosting)
        {
            // Нова швидкість руху
            moveSpeed = 10f;
            // Старт таймеру
            boostTimer+= Time.deltaTime;
            // Таймер рахує 7 секунд
            if (boostTimer > 7f)
            {
                //Повернення до початкових налаштувань
                moveSpeed = 7f;
                boostTimer= 0;
                boosting = false;
            }
        }
        // Виклик методу для реалізації анімування
        UpdateAnimationState();
    }

    // Метод для активації прискорення при стиканні з об'єктом з тегом speed_col
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("speed_col"))
        {
            pinaplesAudioSource.Play();
            Destroy(collision.gameObject);
            boosting = true;
        }
    }

    // Мктод для стрибку
    public void Jump()
    {
            jumpSoundEffects.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);      
            UpdateAnimationState();
    } 

    // Метод реалізації анімування
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
