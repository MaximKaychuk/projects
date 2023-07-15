using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController1 : MonoBehaviour
    {
        public float speed;
        private Animator animator;
        private Rigidbody2D rb;
        private bool facingRight = true;
        public Animator anim;
        private bool isRunning = false;

        private void Start()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            // �������� ���� �� ������������
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // ������������� �������� ��������
            Vector2 movement = new Vector2(horizontalInput, verticalInput);
            movement.Normalize();
            rb.velocity = movement * speed;

            // ������������� �������� ��������� "IsRunning"
            animator.SetBool("IsRunning", isRunning);

            if (movement.magnitude > 0)
            {
                isRunning = true;
                animator.SetBool("IsRunning", isRunning);
            }
            else
            {
                isRunning = false;
                animator.SetBool("IsRunning", isRunning);
            }
            if (movement.magnitude > 0.1f)
            {
                // ��������� �������� �������� ���������
                animator.speed = movement.magnitude;
            }
            else
            {
                animator.speed = 1f;
            }
            if (movement.magnitude == 0)
            {
                isRunning = false;
                animator.SetBool("IsRunning", isRunning);
            }

        }

        private void FixedUpdate()
        {
            // ���������� ����������� ������� ���������
            if (facingRight && rb.velocity.x < 0)
            {
                Flip();
            }
            else if (!facingRight && rb.velocity.x > 0)
            {
                Flip();
            }
        }

        private void Flip()
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
public class TopDownCharacterController
{
    private int currentLayer; // ���������� ��� �������� �������� ����

    public void MoveToLayer(int layer)
    {
        // ���������, �������� �� ����� ���� ����������
        if (IsValidLayer(layer))
        {
            // ��������� �������� ��� ����������� �� ����� ����
            switch (layer)
            {
                case 1:
                    // �������� ��� ����������� �� ���� 1
                    break;
                case 2:
                    // �������� ��� ����������� �� ���� 2
                    break;
                case 3:
                    // �������� ��� ����������� �� ���� 3
                    break;
                default:
                    // �������� ��� ������ �����
                    break;
            }

            // ��������� ������� ����
            currentLayer = layer;
        }
        else
        {
            // ��������� ������������� ����
        }
    }

    private bool IsValidLayer(int layer)
    {
        // ���������, �������� �� ���� ����������
        if (layer >= 1 && layer <= 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}