// Класс реалізації логіки "прилипання до платформи"
using UnityEngine;

public class tickyPlatform : MonoBehaviour
{
    //Обробка події зіткнення
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {        
            // Об'єкт, що натикається стає дочернім елементом об'єка класа 
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Об'єкт, що натикається перестає бути дочернім елементом об'єка класа 
            collision.gameObject.transform.SetParent(null);
        }
    }
}
