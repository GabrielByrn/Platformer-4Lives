// ���� ��� ������� ������� ��� �������
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    private Animator anim;
    // ������, ���� ���� ���������� ��� �������
    [SerializeField] public string triggerName;
    

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ��������� �������
            anim.SetTrigger(triggerName);
        }
    }
    
}
