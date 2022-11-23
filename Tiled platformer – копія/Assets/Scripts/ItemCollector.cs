// Клас для реалізація збору предметів
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    // Змінна кількості зібраних предметів
    private int pineapples = 0;

    // Текстове поле для виведення кількості зібраних 
    [SerializeField] private Text pinaplesText;

    // Звук при зібранні об'єкта
    [SerializeField] private AudioSource pinaplesAudioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // При стиканні з об'єктом з тегом pine програється звук,
        // об'єк знищується, кількість зібраних збільшується та виводиться 
        if (collision.gameObject.CompareTag("pine"))
        {
            pinaplesAudioSource.Play();
            Destroy(collision.gameObject);
            pineapples++;
            pinaplesText.text = pineapples.ToString();
        }
    }
}
