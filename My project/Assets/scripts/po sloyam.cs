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

        private void Start()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Vector2 dir = Vector2.zero;

            if (Input.GetKey(KeyCode.W))
            {
                dir += Vector2.up;
            }
            if (Input.GetKey(KeyCode.S))
            {
                dir += Vector2.down;
            }
            if (Input.GetKey(KeyCode.A))
            {
                dir += Vector2.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                dir += Vector2.right;
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            rb.velocity = 5 * dir;
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