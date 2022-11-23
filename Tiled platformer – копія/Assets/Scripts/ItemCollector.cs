// ���� ��� ��������� ����� ��������
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    // ����� ������� ������� ��������
    private int pineapples = 0;

    // �������� ���� ��� ��������� ������� ������� 
    [SerializeField] private Text pinaplesText;

    // ���� ��� ������ ��'����
    [SerializeField] private AudioSource pinaplesAudioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��� ������� � ��'����� � ����� pine ���������� ����,
        // ��'�� ���������, ������� ������� ���������� �� ���������� 
        if (collision.gameObject.CompareTag("pine"))
        {
            pinaplesAudioSource.Play();
            Destroy(collision.gameObject);
            pineapples++;
            pinaplesText.text = pineapples.ToString();
        }
    }
}
