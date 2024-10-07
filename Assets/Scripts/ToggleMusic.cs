using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour
{
    // Ссылка на AudioSource с музыкой
    public AudioSource musicSource;

    // Спрайт включенной иконки
    public Sprite musicOnIcon;

    // Спрайт выключенной иконки
    public Sprite musicOffIcon;

    // Ссылка на UI Image, где будет меняться иконка
    public Image musicButtonImage;

    // Переменная для отслеживания состояния музыки (включена/выключена)
    private bool isMusicPlaying;

    void Start()
    {
        // Инициализация состояния музыки (проверяем, играет ли музыка при старте)
        isMusicPlaying = musicSource.isPlaying;

        // Обновляем иконку в зависимости от состояния
        UpdateIcon();
    }

    // Этот метод можно привязать к кнопке в Unity через Inspector
    public void ToggleMusicState()
    {
        // Если музыка играет, останавливаем её
        if (isMusicPlaying)
        {
            musicSource.Pause();
            isMusicPlaying = false;
        }
        else // Если музыка не играет, включаем её
        {
            musicSource.Play();
            isMusicPlaying = true;
        }

        // Обновляем иконку в зависимости от состояния
        UpdateIcon();
    }

    // Метод для смены иконки в зависимости от состояния музыки
    private void UpdateIcon()
    {
        if (isMusicPlaying)
        {
            musicButtonImage.sprite = musicOnIcon;
        }
        else
        {
            musicButtonImage.sprite = musicOffIcon;
        }
    }
}