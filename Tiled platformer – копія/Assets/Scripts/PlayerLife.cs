// ���� ��������� ����� �����-����� �����
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // ����� ��� ���������� ������ Die ��� ������� � ��'����� � ����� trap
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Die();
        }
    }

    // ����� ��� ��������� ����� �����
    public void Die()
    {
        // ������ �������
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        // ����������� �����
        deathSoundEffect.Play();

    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
