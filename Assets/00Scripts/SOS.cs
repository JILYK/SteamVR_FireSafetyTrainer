using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Необходимо для работы с UI

public class SOS : MonoBehaviour
{
    public Text timerText; // Переменная для текста
    private bool isTriggered = false; // Флаг срабатывания триггера
    private float startTime; // Время старта таймера

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "finger_middle_2_r")
        {
            print(other.name);
            StartCoroutine(RotateOverTime(1)); //секунды на поворот

            if (!isTriggered) // Если триггер не был срабатыван до этого
            {
                isTriggered = true; // Поднимаем флаг
                startTime = Time.time; // Записываем время старта
                StartCoroutine(UpdateTimer()); // Запускаем корутину таймера
            }

            Config.pressFireAlarm = true;
        }
    }

    IEnumerator UpdateTimer()
    {
        while (isTriggered) // Пока триггер активен
        {
            float elapsedTime = Time.time - startTime; // Вычисляем прошедшее время
            timerText.text = elapsedTime.ToString("F2"); // Обновляем текст таймера с двумя знаками после запятой
            yield return null;
        }
    }

    private Quaternion startRotation;
    private Quaternion endRotation;

    void Start()
    {
        startRotation = transform.rotation; // Начальное вращение - текущее вращение объекта
        endRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90); // Конечное вращение
    }

    IEnumerator RotateOverTime(float duration)
    {
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            yield return null;
        }
        transform.rotation = endRotation;
    }
}