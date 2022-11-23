// ���� ��� ����� �������� ��'���� ����� Boat
using UnityEngine;

public class Boat : MonoBehaviour
{
    private Animator anim;
    [SerializeField] public string triggerName;

    // ����������� ������
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    //������� ��䳿 ��������
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ��'���, �� ���������� ��� ������� ��������� ��'��� ����� Boat
        collision.gameObject.transform.SetParent(transform);

        // �������� ������
        anim.SetTrigger(triggerName);

    }

    // ���� ��'���� ���������� ���������
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ��'���, �� ���������� ������� ���� ������� ���������
            collision.gameObject.transform.SetParent(null);
        }
    }


}
