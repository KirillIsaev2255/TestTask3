using System.Runtime.CompilerServices;
using UnityEngine;
using System;

public class Drop : MonoBehaviour
{
    private Base Base;
    private bool IsPiked = false;
    [SerializeField] private string _base;
    [SerializeField] private bool IsRed;
    static public Func<GameObject,bool> spawnRed;
    static public Func<GameObject,bool> spawnBlue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(IsRed)
            IsPiked =  (bool)(spawnRed?.Invoke(gameObject));
        else
            IsPiked = (bool)(spawnBlue?.Invoke(gameObject));
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsPiked) 
        {
            if (IsRed)
                IsPiked = (bool)(spawnRed?.Invoke(gameObject));
            else
                IsPiked = (bool)(spawnBlue?.Invoke(gameObject));
        }
    }
}
