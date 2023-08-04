using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneNameToLoad;
    private bool playerInsideTrigger;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = true;
            StartCoroutine(WaitAndLoadScene(2f)); // Подождем 2 секунды перед переключением сцены.
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = false; // Если игрок выходит из триггера, обнуляем флаг.
        }
    }

    IEnumerator WaitAndLoadScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (playerInsideTrigger) // Проверяем, что игрок все еще в триггере после ожидания.
        {
            SceneManager.LoadScene("changelvl");
        }
    }
}

