// Клас реалізації логіки "батута"
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private float bounce = 20f;

    // Обробка події зіткнення
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Додання сили bounce до сили відштовхування
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce( Vector2.up*bounce, ForceMode2D.Impulse);
        }
    }
}
