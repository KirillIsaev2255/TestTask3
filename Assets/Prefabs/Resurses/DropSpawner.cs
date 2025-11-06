using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject DropPrefab;
    [SerializeField] private float DelayOfSpawn;
    [SerializeField] private List<Transform> Spawns;
    //private float MinX;
    //private float MaxX;
    //private float MinZ;
    //private float MaxZ;
    private void Start()
    {
        StartCoroutine(Spawner());
    }
    private void Spawn()
    {
        //Vector3 spawnpoint = transform.position + new Vector3(Random.Range(MinX, MaxX),0, Random.Range(MinZ, MaxZ));
        Vector3 spawnpoint = Spawns[Random.Range(0,Spawns.Count)].position;
        Instantiate(DropPrefab, spawnpoint, Quaternion.identity);
    }
    private IEnumerator Spawner()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(DelayOfSpawn);
        }
    }

}
