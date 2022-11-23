// ���� ��� ��������� HP ��'����
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    // ����������� �������� � HP
    [SerializeField] private int _maxHp = 100;

    private int _hp;

    //����������
    public int Hp
    {
        get { return _hp; }
        set
        {
            var isDamage = value < _hp;
            _hp = Mathf.Clamp(value, min: 0, _maxHp);
            if (isDamage)
            {
                Damaged?.Invoke(_hp);
            }
            else
            {
                Healed?.Invoke(_hp);
            }
            if(_hp <= 0)
            {
                Died?.Invoke();
            }
        }
    }

    public int MaxHp => _maxHp;

    // ��䳿
    public UnityEvent<int> Healed;
    public UnityEvent<int> Damaged;
    public UnityEvent Died;

    private void Awake() => _hp = _maxHp;

    // ������ ��������� HP ��'����
    public void Damage(int amount) => Hp -= amount;

    public void Heal(int amount) => Hp += amount;

    public void HealFull() => Hp = _maxHp;

    public void Kill() => Hp = 0;

    public void Adjust(int value) => Hp = value;
}
