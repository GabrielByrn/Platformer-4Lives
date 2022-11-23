//���� ��� ��'���� ���� ������� ���������
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

    // �����, ��� 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            // ���������� ������
            Invoke("FallPlatform", 1f);
            // �������� ��'���� 
            Destroy(gameObject, 4f);
        }
    }

    // ����� ��� ��������� ������ ��'����
     void FallPlatform()
    {
        rb.isKinematic = false;
        boxCollider.isTrigger = true;
    }
}
