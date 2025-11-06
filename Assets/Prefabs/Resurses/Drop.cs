using System.Runtime.CompilerServices;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private Base Base;
    private bool IsPiked = false;
    [SerializeField] private string _base;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Base = GameObject.FindGameObjectWithTag(_base).GetComponent<Base>();
        IsPiked =  Base.SelectDrone(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsPiked) { IsPiked = Base.SelectDrone(gameObject); }
    }
}
