using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CloneSpawner : MonoBehaviour
{
    public GameObject heroPrefab;       // Префаб HeroController
    public GameObject clonePrefab;      // Префаб CloneController
    public float spawnDelay = 1f;       // Задержка спавна клонов в секундах

    [HideInInspector]public List<GameObject> clones;   
    [HideInInspector]public GameObject heroInstance;     // Экземпляр HeroController
    private bool canSpawnClone = true;   // Флаг для контроля спавна клонов


    private void Update()
    {
        if (heroInstance == null)
        {
            SpawnHero();
        }
        // Проверка на пересечение с HeroController или CloneController
        if (!IsOverlappingWithClones() && canSpawnClone)
        {
                StartCoroutine(SpawnClone());
        }
    }
    
    public void SpawnHero()
    {
        // Создание объекта HeroController при старте
        heroInstance = Instantiate(heroPrefab, transform.position, Quaternion.identity);
    }

    private bool IsOverlappingWithClones()
    {
        // Проверка на пересечение с HeroController или CloneController
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f); // Используем радиус для проверки пересечения
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Hero") || collider.gameObject.CompareTag("Clone"))
            {
                return true; // Объект пересекается
            }
        }
        return false; // Объект не пересекается
    }

    private IEnumerator SpawnClone()
    {
        // Создание CloneController в центре спавнера
        GameObject clone = Instantiate(clonePrefab, transform.position, Quaternion.identity);
        clones.Add(clone);
        canSpawnClone = false; // Отключаем спавн до следующей итерации

        // Ждем заданное время перед следующей проверкой спавна
        yield return new WaitForSeconds(spawnDelay);

        // Разрешаем спавн клонов снова
        canSpawnClone = true;
    }
}