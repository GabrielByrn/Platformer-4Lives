// Клас реалізації логіки руху між декількома точками
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    // Масив об'єктів, між якими буде рух
    [SerializeField] private GameObject[] waypoints;

    private int currentWaypointIndex = 0;

    // Швидкість руху
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        // якщо перша точка занадто близько змінюємо індекс поточної точки на наступний
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length) {
                currentWaypointIndex = 0;
                } 
        }
        // Задання вектору руху
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime*speed);
    }
}
