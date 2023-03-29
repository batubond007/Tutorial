using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject zombie;
    public float spawnDelay;

    private void Start()
    {
        StartCoroutine(ZombieSpawner());
    }

    private IEnumerator ZombieSpawner()
    {
        while (true)
        {
            float x = Random.Range(-10, 10);
            float z = Random.Range(-10, 10);
            Instantiate(zombie, new Vector3(x, 0.5f, z), Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
