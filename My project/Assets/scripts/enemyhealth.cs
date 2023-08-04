using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // ћаксимальное здоровье противника
    private int currentHealth; // “екущее здоровье противника

    // «десь можно добавить код дл€ обработки событий смерти противника, если нужно
    // Ќапример, анимации, звуки, очки игрока и т.д.

    private void Start()
    {
        currentHealth = maxHealth; // ”становка начального здоровь€ противника
    }

    // ћетод дл€ нанесени€ урона противнику
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die(); // ¬ызываем метод смерти противника, если его здоровье упало до нул€
        }
    }

    // ћетод дл€ обработки смерти противника
    private void Die()
    {
        // «десь можно добавить код дл€ обработки смерти противника
        // Ќапример, уничтожение GameObject противника и т.д.
        Destroy(gameObject);
    }
}

