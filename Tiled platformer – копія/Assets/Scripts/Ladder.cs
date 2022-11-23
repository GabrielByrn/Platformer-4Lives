// ���� ��� ��������� ������ ����� ��� ������� 
// � ��'����� ���� �������
using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] float speed = 5;
    PlayerMovement pm;

    private void OnTriggerStay2D(Collider2D other)
    {
        // ��� ������� �������� ��������� ����� ��� 0
        other.GetComponent<Rigidbody2D>().gravityScale = 0;

        // ��� ���� ��������
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

    // ��� ��������� �������� �������� ��������� ����������� �� ����������� ��������
    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale = 3;
    }
}
