// ���� ��� ��������� ��������� �� ��������� ������� �����
using UnityEngine;
using UnityEngine.Events;

public class LivesCounter : MonoBehaviour
{
    // ������ ������ �����
    [SerializeField] private float _liveImageWidth = 44f;
    [SerializeField] private int _maxNumOfLives = 4;
    [SerializeField] private int _numOfLives =4;

    private RectTransform _rect;

    // ����� ���������� �����
    public UnityEvent OutOfLives;

    // ����������
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

    // ������� �������  ����� �����
    private void AdjustImageWidth()
    {
        _rect.sizeDelta = new Vector2(_liveImageWidth * _numOfLives, _rect.sizeDelta.y);
    }

    // ����� ������� ����� 
    public void AddLife(int num = 1)
    {
        NumOfLives += num;
    }

    //����� �������� �����
    public void  RemoveLife(int num = 1)
    {
        NumOfLives -= num;
    }
    
}
