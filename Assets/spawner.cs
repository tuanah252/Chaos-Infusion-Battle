using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnInterval = 3f;
    public int maxSpawnCount = 7; // Số lượng tối đa các đối tượng được Instantiate
    public Transform[] targets; // Mảng các vị trí mục tiêu
    private bool canSpawn = true;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            GameObject[] currentObjects = GameObject.FindGameObjectsWithTag("soldier");
            int currentSpawnCount = currentObjects.Length;

            if (currentSpawnCount < maxSpawnCount)
            {
                int spawnCount = Mathf.Min(maxSpawnCount - currentSpawnCount, 5); // Giới hạn số lượng đối tượng được Instantiate trong lần gọi này
                for (int i = 0; i < spawnCount; i++)
                {
                    // Chọn ngẫu nhiên một vị trí mục tiêu từ mảng "targets"
                    Transform randomTarget = targets[Random.Range(0, targets.Length)];

                    GameObject obj = Instantiate(prefab, randomTarget.position, Quaternion.identity);
                    yield return new WaitForSeconds(spawnInterval);
                }
            }

            yield return null;
        }
    }
}
