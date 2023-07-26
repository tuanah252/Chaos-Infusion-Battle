using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracer : MonoBehaviour
{
    public float speed = 1.0f; // Tốc độ di chuyển
    public float minDistance = 0.1f;
    public float rotationSpeed = 180f; // Tốc độ xoay của nhân vật (góc mỗi giây)
    private Animator anim;
    private GameObject targetSoldier;

    void Start()
    {
        FindTarget();
        anim = GetComponent<Animator>();
    }

    void FindTarget()
    {
        GameObject[] soldiers = GameObject.FindGameObjectsWithTag("bowman");
        if (soldiers.Length > 0)
        {
            // Chọn ngẫu nhiên một kẻ địch từ danh sách
            targetSoldier = soldiers[Random.Range(0, soldiers.Length)];
        }
    }

    void Update()
    {
        if (targetSoldier != null)
        {
            MoveToTarget();
            
        }
    }

    void MoveToTarget()
    {
        if (Vector3.Distance(transform.position, targetSoldier.transform.position) > minDistance)
        {
            // Calculate the direction vector from the current position to the target position
            Vector3 direction = (targetSoldier.transform.position - transform.position).normalized;

            // Calculate the movement vector based on the speed and the time between frames
            Vector3 movement = direction * speed * Time.deltaTime;

            // Move the object by adding the movement vector to the current position
            transform.position += movement;
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bowman"))
        {
            anim.SetTrigger("Attack");
            Destroy(collision.gameObject); // Hủy bỏ đối tượng A
        }
    }
}
