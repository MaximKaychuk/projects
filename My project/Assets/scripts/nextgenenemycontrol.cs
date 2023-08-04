using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    public float speed; // Скорость врага
    public float patrolRadius; // Радиус патрулирования вокруг начальной точки
    public float followRadius; // Радиус, в котором враг следит за персонажем
    public Transform patrolCenter; // Начальная точка патрулирования
    public Transform target; // Цель врага (игрок)

    private Rigidbody2D rb;
    private Vector3 initialPosition; // Начальная позиция для патрулирования

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found!");
        }

        if (patrolCenter == null)
        {
            patrolCenter = transform; // Если начальная точка патрулирования не задана, используем текущую позицию врага
        }

        initialPosition = patrolCenter.position;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer > followRadius)
        {
            Patrol();
        }
        else
        {
            ChasePlayer();
        }
    }

    void Patrol()
    {
        // Патрулирование - движение по кругу в заданном радиусе
        Vector3 direction = (initialPosition - transform.position).normalized;
        rb.velocity = direction * speed;

        // Добавьте отладочный вывод, чтобы убедиться, что метод вызывается и скорость вычисляется правильно.
        Debug.Log("Patrolling. Velocity: " + rb.velocity);
    }

    void ChasePlayer()
    {
        // Преследование - движение к игроку
        Vector3 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;

        // Добавьте отладочный вывод, чтобы убедиться, что метод вызывается и скорость вычисляется правильно.
        Debug.Log("Chasing player. Velocity: " + rb.velocity);
    }
}
