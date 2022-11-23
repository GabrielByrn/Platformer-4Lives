// ����� ��� ��������� �������� � ���� �� �����
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // ���� ���������� ����
    private AudioSource finishAudioSource;

    // ����� ��� �������� ���������� ����
    private bool levelComplited = false;        

    private void Start()
    {
        finishAudioSource = GetComponent<AudioSource>();
    }

    // �����, ���� ��'��� ������ �����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelComplited)
        {
            // ����������� �����
            finishAudioSource.Play();
            // ���������� ������ � ���������
            Invoke("ComleteLevel", 2f);
            levelComplited = true;
        }
    }
    
    // �����  ���������� ���������� ���� (�����)
    private void ComleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
