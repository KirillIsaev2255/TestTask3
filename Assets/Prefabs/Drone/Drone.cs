using NUnit.Framework;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Drone : MonoBehaviour
{
    //public List<Drone> Drones { get; private set; }
    [SerializeField] private string _base;
    [SerializeField] private ParticleSystem effect;
    private bool IsActive=true;
    private bool IsGoingToBase=false;
    private bool IsPick=false;
    private NavMeshAgent agent;
    private GameObject Base;
    private GameObject NowDrop;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     void Start()
     {
            agent = GetComponent<NavMeshAgent>();
            Base = GameObject.FindGameObjectWithTag(_base);
     }
    private void Update()
    {
        if (NowDrop)
        {
            if(Vector3.Distance(transform.position, NowDrop.transform.position) < 3f&& !IsPick)
                StartCoroutine(Picker());
        }
        if (IsGoingToBase&& Vector3.Distance(transform.position, Base.transform.position)<5f) 
        {
            ReturnDrop();
        }
    }
    public float SetDistance(Transform drop)
    {
        if (IsActive)
        {
           return Vector3.Distance(transform.position, drop.position);
        }
        return -1f;

    }
    private void GoToBase() 
    {
        agent.SetDestination(Base.transform.position);
        IsGoingToBase = true;
    }
    public void PickUp(GameObject drop)
    {
        IsActive = false;
        NowDrop = drop;
        agent.SetDestination(NowDrop.transform.position);
    }
    public void ReturnDrop() { IsActive = true;IsGoingToBase = false; effect.Play(); }
    private IEnumerator Picker()
    {
        print("Pick");
        IsPick = true;
        agent.isStopped = false;
        yield return new WaitForSeconds(2f);
        IsPick = false;
        Destroy(NowDrop);
        GoToBase();
    }
}
