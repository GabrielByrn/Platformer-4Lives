// ���� ��������� ��������� �����
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Animator _animator;

    // ʳ������ ���������� �����
    [SerializeField] int _damageAmount;

    private void Awake()
    {
        _animator=GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // �������� �� �� ��'��� � ���� ���������� Health
        if (col.TryGetComponent<Health>(out var health))
        {
            // ������ �������
            _animator.SetTrigger("Activate");
            // ���������� ������ ��������� �����
            health.Damage(amount: _damageAmount);
            _animator.SetTrigger("Activate");
        }
    }
}
