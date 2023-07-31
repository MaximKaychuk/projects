
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Добавьте это

public class PlayerHealth : MonoBehaviour
{
    public int health;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Здесь вы можете добавить какую-то логику для анимации смерти или других действий перед перезапуском уровня
        RestartLevel();
    }

    void RestartLevel()
    {
        // Перезагрузка текущей сцены
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
