// Клас реалізації нанесення урону
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Animator _animator;

    // Кількість нанесеного урону
    [SerializeField] int _damageAmount;

    private void Awake()
    {
        _animator=GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Перевірка чи має об'єкт з яким стикаються Health
        if (col.TryGetComponent<Health>(out var health))
        {
            // Запуск анімації
            _animator.SetTrigger("Activate");
            // ВИкликання методу нанесення урону
            health.Damage(amount: _damageAmount);
            _animator.SetTrigger("Activate");
        }
    }
}
