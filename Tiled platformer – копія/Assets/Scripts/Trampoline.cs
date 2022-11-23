// ���� ��������� ����� "������"
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private float bounce = 20f;

    // ������� ��䳿 ��������
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ������� ���� bounce �� ���� �������������
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce( Vector2.up*bounce, ForceMode2D.Impulse);
        }
    }
}
