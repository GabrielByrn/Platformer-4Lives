// Клас реалізації логіки життя-смерті героя
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Метод для викликання методу Die при стиканні з об'єктом з тегом trap
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Die();
        }
    }

    // Метод для реалізації смерті героя
    public void Die()
    {
        // Запуск анімації
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        // Програвання звуку
        deathSoundEffect.Play();

    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
