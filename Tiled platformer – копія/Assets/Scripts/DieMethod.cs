// ���� ��� ������� ��䳿, ���� ����� ������'� 0
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieMethod : MonoBehaviour
{
    // ���� ��� ��������� ������'�  
    private Health health;
    private Animator anim;

    // ����� ��������
    [SerializeField] private Vector2 _respawn = Vector2.zero;
    [SerializeField] private AudioSource deathSoundEffect;

    private void Awake()
    {
        health = GetComponent<Health>();
        anim = GetComponent<Animator>();
    }

    //�� = 0
    public void OnDied()
    {
        // ��������� ������� 
        anim.SetTrigger("death");
        // ����������� ����� 
        deathSoundEffect.Play();
        // ������� �� ������ �������
        transform.position = _respawn;
        //������������ ������'� 100
        health.HealFull();
    }

    //����� ��� ��������, ���� ����� ���������
    public void OutOfLives()
    {
        SceneManager.LoadScene("End Screen");
    }
}
