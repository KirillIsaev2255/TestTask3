using UnityEngine;
using System.Collections.Generic;


public class Base : MonoBehaviour
{
    private List<Drone> drones = new List<Drone>();
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private GameObject DronePrefab;
    [SerializeField] private int CountOfDrons;
    [SerializeField] private bool IsRed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnDron();
        if(IsRed)
        Drop.spawnRed += SelectDrone;
        else Drop.spawnBlue += SelectDrone;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnDron()
    {
        for (int i = 0; i < CountOfDrons; i++)
        {
            GameObject drone =  Instantiate(DronePrefab,SpawnPoint.position,Quaternion.identity);
            drones.Add(drone.GetComponent<Drone>());
        }
    }
    public bool SelectDrone(GameObject drop)
    {
        float minDist = float.MaxValue;
        int index = -1;
        for (int i = 0; i < drones.Count; i++)
        {
           float dist =  drones[i].SetDistance(drop.transform);
            if (minDist > dist && dist>0) 
            { index = i; minDist = dist; }
        }
        if(index>=0){drones[index].PickUp(drop); return true;}
        return false;        
    }
    private void OnDestroy()
    {
        if (IsRed)
            Drop.spawnRed -= SelectDrone;
        else Drop.spawnBlue -= SelectDrone;
    }
}
