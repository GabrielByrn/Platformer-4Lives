// Клас для реалізації фізики героя при контакті 
// з об'єктом типу Драбина
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] float speed = 5;
    PlayerMovement pm;

    private void OnTriggerStay2D(Collider2D other)
    {
        // При контакті значення гравітації героя стає 0
        other.GetComponent<Rigidbody2D>().gravityScale = 0;

        // Для руху драбиною
            if (Input.GetKey(KeyCode.W))
            {
            other.GetComponent<Rigidbody2D>().velocity = new Vector3(0, speed);
        }
            else if (Input.GetKey(KeyCode.S))
            {
            other.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -speed);
        }
            else if (Input.GetKey(KeyCode.Space))
        {
            pm.Jump();
        }

        else
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
        }
    }

    // При завершенні контакту значення гравітації повертається до початкового значення
    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale = 3;
    }
}
