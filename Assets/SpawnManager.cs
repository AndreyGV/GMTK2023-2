using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject monkeyPrefab;
    public float spawnPosX = 3500;
    public float spawnRangeY = 1000;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 SpawnPos = new Vector3(spawnPosX, Random.Range(-spawnRangeY, spawnRangeY), 0);
            Instantiate(monkeyPrefab, SpawnPos, monkeyPrefab.transform.rotation);
        }
    }
}
