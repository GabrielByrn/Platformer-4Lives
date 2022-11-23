// Кляс для запуску анімації при зіткненні
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    private Animator anim;
    // Тригер, який буде активовано при зіткненні
    [SerializeField] public string triggerName;
    

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Активація тригеру
            anim.SetTrigger(triggerName);
        }
    }
    
}
