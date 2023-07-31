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

        private void Start()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
         
            // Получаем ввод от пользователя
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Устанавливаем скорость движения
            Vector2 movement = new Vector2(horizontalInput, verticalInput);
            movement.Normalize();
            rb.velocity = movement * speed;

            // Переключаем между анимациями бега и покоя
            if (movement.magnitude > 0.01f)
            {
                animator.SetBool("IsRunning", true);
            }
            else
            {
                animator.SetBool("IsRunning", false);
            }

            if (movement.magnitude > 0.1f)
            {
                // Добавляем проверку скорости персонажа
                animator.speed = movement.magnitude;
            }
            else
            {
                animator.speed = 1f;
            }

            anim.SetFloat("HorisontalMove", Mathf.Abs(horizontalInput));
            Debug.Log("HorisontalMove: " + Mathf.Abs(Input.GetAxis("Horizontal")));
            Debug.Log("IsRunning: " + animator.GetBool("IsRunning"));
        }

        private void FixedUpdate()
        {
            // Определяем направление взгляда персонажа
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