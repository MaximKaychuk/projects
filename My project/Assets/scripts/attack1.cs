using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack1 : MonoBehaviour
{
    public Animator animator;
    public int damageAmount = 20; // Количество урона, наносимого противнику
    public float attackRange = 1.5f; // Расстояние, на котором атака будет наносить урон противнику

    private Transform playerTransform; // Ссылка на трансформ игрока

    private void Start()
    {
        playerTransform = transform; // Получаем ссылку на трансформ игрока
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("attack");
    }

    // Метод для обработки события окончания анимации атаки
    public void AttackEnd()
    {
        // Проверяем наличие противников в зоне атаки
        Collider2D[] enemies = Physics2D.OverlapCircleAll(playerTransform.position, attackRange);
        foreach (Collider2D enemyCollider in enemies)
        {
            // Проверяем, является ли объект в зоне атаки противником
            EnemyHealth enemyHealth = enemyCollider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount); // Вызываем метод нанесения урона противнику
            }
        }
    }

    // Визуализация зоны атаки в редакторе Unity
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}