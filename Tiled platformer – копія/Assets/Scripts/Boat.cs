// Клас для опису поведінки об'єктів класа Boat
using UnityEngine;

public class Boat : MonoBehaviour
{
    private Animator anim;
    [SerializeField] public string triggerName;

    // Ініціалізація змінних
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    //Обробка події зіткнення
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Об'єкт, що натикається стає дочернім елементом об'єка класа Boat
        collision.gameObject.transform.SetParent(transform);

        // Активуємо тригер
        anim.SetTrigger(triggerName);

    }

    // Якщо об'єкти перестають стикатися
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Об'єкт, що натикається перестає бути дочернім елементом
            collision.gameObject.transform.SetParent(null);
        }
    }


}
