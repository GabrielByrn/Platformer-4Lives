// Клас реалізації роботи шкали HP
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Об'єкт, HP якого відображатиметься
    [SerializeField] private Health _health;

    // Картинка заповнення шкали
    [SerializeField] private RectTransform _barRect;

    // Маска картинки
    [SerializeField] private RectMask2D _mask;

    // Тестовий індекатор
    [SerializeField] private Text _hpIndicator;

    private float _maxRightMask;
    private float _initialRightMask;

    private void Start()
    {
        // Ширина лінії заповнення
        _maxRightMask = _barRect.rect.width - _mask.padding.x - _mask.padding.z;

        //Виведення початкових значень
        _hpIndicator.text = _health.Hp + "/" +_health.MaxHp;
        _initialRightMask = _mask.padding.z;
    }
    public void SetValue(int newValue)
    {
        //Задання нової ширини лінії заповнення
        var targetWidth = newValue * _maxRightMask / _health.MaxHp;

        // ЗАдання нової ширини маски
        var newRightMask =_maxRightMask + _initialRightMask - targetWidth;
        var padding =_mask.padding;
        padding.z = newRightMask;
        _mask.padding = padding;

        // Виведення значень у тексті 
        _hpIndicator.text = newValue + "/" + _health.MaxHp;
    }
}
