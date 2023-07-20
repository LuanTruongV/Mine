using System;
using UnityEngine;


public class Square : MonoBehaviour,IDestroy
{
    
    [SerializeField] private GameObject _detectGO;
    [SerializeField] private float _time = 1f;
    public void UnDetect()
    {
        _detectGO.SetActive(false);
    }
    public void Detect()
    {
        _detectGO.SetActive(true);
    }

    public void Destroy()
    {
        Destroy(gameObject,_time);
    }
}