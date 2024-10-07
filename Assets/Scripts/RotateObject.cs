using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float speed = 10f; // Скорость вращения в градусах за секунду

    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}