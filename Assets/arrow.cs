using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public float arrowSpeed = 10f; // Tốc độ mũi tên
    public float destroyTime = 1f; // Thời gian tồn tại của mũi tên (giây)

    private void Start()
    {
        // Khi khởi tạo mũi tên, hủy nó sau khoảng thời gian destroyTime
        Destroy(gameObject, destroyTime);
    }

    private void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Xử lý va chạm với các đối tượng khác (nếu cần)
        // Ví dụ: hủy mũi tên khi va chạm với một kẻ địch
       if (collision.gameObject.CompareTag("soldier")) // Kiểm tra va chạm với đối tượng B
        {
            Destroy(gameObject); // Hủy bỏ đối tượng A
            Destroy(collision.gameObject); 
        }
    }
}
