using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack1 : MonoBehaviour
{
    public Animator animator;
    public int damageAmount = 20; // ���������� �����, ���������� ����������
    public float attackRange = 1.5f; // ����������, �� ������� ����� ����� �������� ���� ����������

    private Transform playerTransform; // ������ �� ��������� ������

    private void Start()
    {
        playerTransform = transform; // �������� ������ �� ��������� ������
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

    // ����� ��� ��������� ������� ��������� �������� �����
    public void AttackEnd()
    {
        // ��������� ������� ����������� � ���� �����
        Collider2D[] enemies = Physics2D.OverlapCircleAll(playerTransform.position, attackRange);
        foreach (Collider2D enemyCollider in enemies)
        {
            // ���������, �������� �� ������ � ���� ����� �����������
            EnemyHealth enemyHealth = enemyCollider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount); // �������� ����� ��������� ����� ����������
            }
        }
    }

    // ������������ ���� ����� � ��������� Unity
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}