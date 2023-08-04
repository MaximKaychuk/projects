using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneButton : MonoBehaviour
{
    public float delay = 1f; // задержка в секундах

    public void OnButtonPress()
    {
        StartCoroutine(LoadSceneAfterDelay(delay)); // начать корутину
    }

    IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // ожидать указанное количество секунд
        SceneManager.LoadScene("Scene Demo"); // загрузить сцену
    }
}
