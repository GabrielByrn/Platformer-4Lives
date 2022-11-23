// Клас для реалізації підрахунку та виведення кількості життів
using UnityEngine;
using UnityEngine.Events;

public class LivesCounter : MonoBehaviour
{
    // Ширина одного життя
    [SerializeField] private float _liveImageWidth = 44f;
    [SerializeField] private int _maxNumOfLives = 4;
    [SerializeField] private int _numOfLives =4;

    private RectTransform _rect;

    // Івент закінчилися життя
    public UnityEvent OutOfLives;

    // Властивості
    public int NumOfLives
    {
        get { return _numOfLives; }
        private set
        {
            if (value < 0)
            {
                OutOfLives?.Invoke();
            }
            _numOfLives = Mathf.Clamp(value, 0, _maxNumOfLives);
            AdjustImageWidth();
        }
    }

    private void Awake()
    {
        _rect = transform as RectTransform;
        AdjustImageWidth();
    }

    // Задання вширини  рядка життів
    private void AdjustImageWidth()
    {
        _rect.sizeDelta = new Vector2(_liveImageWidth * _numOfLives, _rect.sizeDelta.y);
    }

    // Метод додання життя 
    public void AddLife(int num = 1)
    {
        NumOfLives += num;
    }

    //Метод віднімання життя
    public void  RemoveLife(int num = 1)
    {
        NumOfLives -= num;
    }
    
}
