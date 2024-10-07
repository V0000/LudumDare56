using System;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{

    // Ссылка на UI элемент (например, Image или Text)
    private Image uiElement;

    private void Awake()
    {
        uiElement = GetComponent<Image>();
    }

    // Метод для вызова Fade In
    public void StartFadeIn(float duration)
    {
        StartCoroutine(FadeIn(uiElement, duration));
    }

    // Метод для вызова Fade Out
    public void StartFadeOut(float duration)
    {
        StartCoroutine(FadeOut(uiElement, duration));
    }

    // Корутин для эффекта Fade In
    IEnumerator FadeIn(Image image, float duration)
    {
        Color color = image.color;
        float startAlpha = color.a;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, time / duration);
            image.color = color;
            yield return null;
        }

        color.a = startAlpha; // Убедимся, что альфа установлена в финальное значение
        image.color = color;
    }

    // Корутин для эффекта Fade Out
    IEnumerator FadeOut(Image image, float duration)
    {
        Debug.Log($"image == null {image == null}");
        Color color = image.color;
        float startAlpha = color.a;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(1, 0, time / duration);
            image.color = color;
            yield return null;
        }

        color.a = 0; // Убедимся, что альфа установлена в финальное значение
        image.color = color;
    }
}