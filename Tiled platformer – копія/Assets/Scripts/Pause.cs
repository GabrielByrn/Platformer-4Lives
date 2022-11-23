// ���� ��� ��������� ������� ��'���� � ����� �����
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;

    // ��� ��������� �� Escape ����������� ���� �����
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    // ����� �����
    public void PauseGame()
    {
        // ��� �������� 
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    //����� �����������
    public void Resume()
    {
        // �������� ���� =1
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    //����� ��� �������� �� ��������� ����
    public void GoToMenu()
    {
        SceneManager.LoadScene("Start Screen 1");
    }
}
