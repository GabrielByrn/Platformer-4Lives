// Клас для обробки події, коли рівень здоров'я 0
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieMethod : MonoBehaviour
{
    // Поле для зберігання здоров'я  
    private Health health;
    private Animator anim;

    // Точка респауну
    [SerializeField] private Vector2 _respawn = Vector2.zero;
    [SerializeField] private AudioSource deathSoundEffect;

    private void Awake()
    {
        health = GetComponent<Health>();
        anim = GetComponent<Animator>();
    }

    //Нр = 0
    public void OnDied()
    {
        // Активація тригеру 
        anim.SetTrigger("death");
        // Програвання звуку 
        deathSoundEffect.Play();
        // Респавн на заданій позиції
        transform.position = _respawn;
        //Встановлення здоров'я 100
        health.HealFull();
    }

    //Метод для ситуації, коли життя вичерпано
    public void OutOfLives()
    {
        SceneManager.LoadScene("End Screen");
    }
}
