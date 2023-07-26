using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowmanspawn : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] targets;
    // Start is called before the first frame update
    public void Spawn() {
        Transform randomTarget = targets[Random.Range(0, targets.Length)];
        GameObject obj = Instantiate(prefab, randomTarget.position, Quaternion.identity);
    }
}
