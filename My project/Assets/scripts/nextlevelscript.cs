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
            StartCoroutine(WaitAndLoadScene(2f)); // �������� 2 ������� ����� ������������� �����.
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = false; // ���� ����� ������� �� ��������, �������� ����.
        }
    }

    IEnumerator WaitAndLoadScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (playerInsideTrigger) // ���������, ��� ����� ��� ��� � �������� ����� ��������.
        {
            SceneManager.LoadScene("changelvl");
        }
    }
}

