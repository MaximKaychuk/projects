using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed; // Скорость врага
    public float followRadius; // Радиус, в котором враг следит за персонажем
    public float maxDistance; // Максимальное расстояние между врагом и персонажем, чтобы враг начал двигаться
    private Transform target; // Цель врага (игрок)

    private Rigidbody2D rb;

   void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (target != null)
        {
            Debug.Log("Target found: " + target.name);
        }
        else
        {
            Debug.LogError("Target not found!");
        }

        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Debug.Log("Rigidbody2D found.");
        }
        else
        {
            Debug.LogError("Rigidbody2D not found!");
        }
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        if (Vector3.Distance(transform.position, target.position) > maxDistance)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * speed;

            // Добавьте отладочный вывод, чтобы убедиться, что метод вызывается и скорость вычисляется правильно.
            Debug.Log("Moving towards player. Velocity: " + rb.velocity);
        }
        else
        {
            StopMoving();
        }
    }

    void StopMoving()
    {
        // Останавливаем движение врага
        rb.velocity = Vector2.zero;
    }
}
