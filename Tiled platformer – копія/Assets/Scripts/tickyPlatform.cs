// ����� ��������� ����� "���������� �� ���������"
using UnityEngine;

public class tickyPlatform : MonoBehaviour
{
    //������� ��䳿 ��������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {        
            // ��'���, �� ���������� ��� ������� ��������� ��'��� ����� 
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // ��'���, �� ���������� ������� ���� ������� ��������� ��'��� ����� 
            collision.gameObject.transform.SetParent(null);
        }
    }
}
