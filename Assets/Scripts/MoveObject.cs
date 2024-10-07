using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // Скорость перемещения
    public float speed = 1f;
    
    // Граничные значения по оси Y
    private float minY = -1f;
    private float maxY = 0f;
    
    // Направление движения
    private bool movingDown = true;

    void Update()
    {
        // Получаем текущую позицию объекта
        Vector3 currentPosition = transform.position;

        // Если движемся вниз
        if (movingDown)
        {
            // Перемещаем объект вниз
            currentPosition.y -= speed * Time.deltaTime;

            // Если достигли нижней границы
            if (currentPosition.y <= minY)
            {
                currentPosition.y = minY;
                movingDown = false;
            }
        }
        else
        {
            // Перемещаем объект вверх
            currentPosition.y += speed * Time.deltaTime;

            // Если достигли верхней границы
            if (currentPosition.y >= maxY)
            {
                currentPosition.y = maxY;
                movingDown = true;
            }
        }

        // Применяем новую позицию к объекту
        transform.position = currentPosition;
    }
}