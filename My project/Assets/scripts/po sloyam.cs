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
    private int currentLayer; // переменная для хранения текущего слоя

    public void MoveToLayer(int layer)
    {
        // проверяем, является ли новый слой допустимым
        if (IsValidLayer(layer))
        {
            // выполняем действия для перемещения на новый слой
            switch (layer)
            {
                case 1:
                    // действия для перемещения на слой 1
                    break;
                case 2:
                    // действия для перемещения на слой 2
                    break;
                case 3:
                    // действия для перемещения на слой 3
                    break;
                default:
                    // действия для других слоев
                    break;
            }

            // обновляем текущий слой
            currentLayer = layer;
        }
        else
        {
            // обработка недопустимого слоя
        }
    }

    private bool IsValidLayer(int layer)
    {
        // проверяем, является ли слой допустимым
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