using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    public float speed; // �������� �����
    public float patrolRadius; // ������ �������������� ������ ��������� �����
    public float followRadius; // ������, � ������� ���� ������ �� ����������
    public Transform patrolCenter; // ��������� ����� ��������������
    public Transform target; // ���� ����� (�����)

    private Rigidbody2D rb;
    private Vector3 initialPosition; // ��������� ������� ��� ��������������

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found!");
        }

        if (patrolCenter == null)
        {
            patrolCenter = transform; // ���� ��������� ����� �������������� �� ������, ���������� ������� ������� �����
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
        // �������������� - �������� �� ����� � �������� �������
        Vector3 direction = (initialPosition - transform.position).normalized;
        rb.velocity = direction * speed;

        // �������� ���������� �����, ����� ���������, ��� ����� ���������� � �������� ����������� ���������.
        Debug.Log("Patrolling. Velocity: " + rb.velocity);
    }

    void ChasePlayer()
    {
        // ������������� - �������� � ������
        Vector3 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;

        // �������� ���������� �����, ����� ���������, ��� ����� ���������� � �������� ����������� ���������.
        Debug.Log("Chasing player. Velocity: " + rb.velocity);
    }
}
