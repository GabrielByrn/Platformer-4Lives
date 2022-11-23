//Клас для об'єктів типу Падаюча платформа
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider= GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = false;
    }

    // Метод, щоб 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            // Викликання падіння
            Invoke("FallPlatform", 1f);
            // Знищення об'єкту 
            Destroy(gameObject, 4f);
        }
    }

    // Метод для реалізації падіння об'єкту
     void FallPlatform()
    {
        rb.isKinematic = false;
        boxCollider.isTrigger = true;
    }
}
