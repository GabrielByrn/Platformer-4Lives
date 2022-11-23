// Метод для реалізації переходу з рівня на рівень
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // Звук досягнення кінця
    private AudioSource finishAudioSource;

    // Змінна для перевірки завершення рівня
    private bool levelComplited = false;        

    private void Start()
    {
        finishAudioSource = GetComponent<AudioSource>();
    }

    // Метод, коли об'єкт досягає фініша
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelComplited)
        {
            // Програвання звуку
            finishAudioSource.Play();
            // Викликання методу з затримкою
            Invoke("ComleteLevel", 2f);
            levelComplited = true;
        }
    }
    
    // Метод  викликання наступного рівня (сцени)
    private void ComleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
