using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowmanspawn : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] targets;
    public int maxBowmanCount = 5; // Số lượng tối đa các bowman có thể có trong game

    private void Start()
    {
        // Đếm số lượng bowman hiện có trong game khi bắt đầu
        int currentBowmanCount = CountBowman();
        // Tính số lượng bowman cần spawn
        int remainingBowmanCount = maxBowmanCount - currentBowmanCount;
        // Kiểm tra và spawn bowman nếu cần
        if (remainingBowmanCount > 0)
        {
            for (int i = 0; i < remainingBowmanCount; i++)
            {
                Spawn();
            }
        }
    }

    public void Spawn()
    {
        int currentBowmanCount = CountBowman();
        if (currentBowmanCount < maxBowmanCount)
        {
            Transform randomTarget = targets[Random.Range(0, targets.Length)];
            GameObject obj = Instantiate(prefab, randomTarget.position, Quaternion.identity);
        }
    }

    private int CountBowman()
    {
        GameObject[] bowmans = GameObject.FindGameObjectsWithTag("bowman");
        return bowmans.Length;
    }
}
