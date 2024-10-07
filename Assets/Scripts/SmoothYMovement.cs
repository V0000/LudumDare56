using UnityEngine;

public class SmoothYMovement : MonoBehaviour
{
    public float speed = 1f;
    public float yMax = 5f;
    public float yMin = -5f;

    private float startTime;
    // Внутренняя переменная для направления движения
    private bool movingDown = true;

    void Update()
    {
        // Получаем текущую позицию объекта
        Vector3 currentPosition = transform.position;

        // Если движемся вниз
        if (movingDown)
        {
            // Линейно перемещаем объект вниз
            currentPosition.y = Mathf.MoveTowards(currentPosition.y, yMin, speed * Time.deltaTime);

            // Если достигли нижней границы, меняем направление
            if (currentPosition.y <= yMin)
            {
                movingDown = false;
            }
        }
        else
        {
            // Линейно перемещаем объект вверх
            currentPosition.y = Mathf.MoveTowards(currentPosition.y, yMax, speed * Time.deltaTime);

            // Если достигли верхней границы, меняем направление
            if (currentPosition.y >= yMax)
            {
                movingDown = true;
            }
        }

        // Применяем новую позицию к объекту
        transform.position = currentPosition;
    }
}