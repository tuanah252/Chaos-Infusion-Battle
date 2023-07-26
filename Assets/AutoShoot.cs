using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    public GameObject arrowPrefab; // Prefab của mũi tên (cần kéo thả prefab vào trường này)
    public Transform firePoint;    // Vị trí bắn mũi tên
    public float shootInterval = 1.0f; // Khoảng thời gian giữa mỗi lần bắn (giây)

    private float shootTimer = 0.0f;
    private bool canShoot = true; // Biến kiểm tra xem nhân vật có thể bắn mũi tên hay không
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Kiểm tra xem đã đến thời điểm bắn mũi tên tiếp theo chưa
        if (canShoot && shootTimer <= 0.0f)
        {
            // Tìm tất cả các đối tượng có tag "soldier"
            GameObject[] soldiers = GameObject.FindGameObjectsWithTag("soldier");

            if (soldiers.Length > 0)
            {
                // Chọn ngẫu nhiên một kẻ địch từ danh sách
                GameObject targetSoldier = soldiers[Random.Range(0, soldiers.Length)];

                // Tạo mũi tên
                ShootArrow(targetSoldier.transform.position);

                // Chỉ bắn một mũi tên trong mỗi lần thực hiện
                canShoot = false;
            }

            // Thiết lập lại thời gian đếm để bắn lần tiếp theo
            shootTimer = shootInterval;
        }
        
        // Giảm thời gian đếm theo thời gian thực
        shootTimer -= Time.deltaTime;

        // Nếu đã hết khoảng thời gian bắn, cho phép bắn mũi tên lần tiếp theo
        if (shootTimer <= 0.0f)
        {
            canShoot = true;
        }
    }

    private void ShootArrow(Vector3 targetPosition)
    {
        // Tạo mũi tên từ prefab tại vị trí bắn mũi tên và hướng đi về phía kẻ địch
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, Quaternion.identity);
        Vector2 direction = (targetPosition - firePoint.position).normalized;
        arrow.GetComponent<Rigidbody2D>().velocity = direction * 10f; // Tốc độ mũi tên

        // Kích hoạt trạng thái bắn mũi tên trong Animator
        anim.SetBool("isShooting", true);
        
    }
}
