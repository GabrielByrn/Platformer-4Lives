// Клас для реалізації функцій об'єктів з панелі пауза
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;

    // При натисканні на Escape викликається меню паузи
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    // Метод паузи
    public void PauseGame()
    {
        // Час зупинено 
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    //Метод продовження
    public void Resume()
    {
        // Швидкість часу =1
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    //Метод для переходу на початкове меню
    public void GoToMenu()
    {
        SceneManager.LoadScene("Start Screen 1");
    }
}
