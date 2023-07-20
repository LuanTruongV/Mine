using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [Header("Size")]
    [SerializeField] private int _size;
    public int Size{get=>_size;}
    [Header("Prefabs")]
    [SerializeField] private GameObject _grassPrefab;
    [SerializeField] private GameObject _dirtPrefab;
    [SerializeField] private GameObject _stonePrefab;

    [Header("Count Layer")] 
    [SerializeField] private int _grassCount;
    [SerializeField] private int _dirtCount;

    private void Start()
    {
        if (_grassCount + _dirtCount > _size)
        {
            Debug.LogError("size <<<<<");
        }
        else
        {
            Gerenal();
        }
        
    }

    private void Gerenal()
    {
        Vector3 chunkPos = transform.position;
        float _sizeSquare = _grassPrefab.transform.localScale.x;
        float athwart = (float)Mathf.Abs(_size%2 - 1) / 2;
        Debug.Log(Mathf.Abs(_size%2-1)/2);
        
        
        for (int width = 0; width < _size; width++)
        {
            for (int length = 0; length < _size; length++)
            {
                for (int height = 0; height < _size; height++)
                { 
                    
                    float x = chunkPos.x-_size/2+width+athwart;
                    float z = chunkPos.z-_size/2+length+athwart;
                    float y = chunkPos.y-height;
                    Vector3 _pos = _sizeSquare*new Vector3(x, y, z);

                    GameObject squareGo;
                    if (height < _grassCount)
                    {
                        squareGo=Instantiate(_grassPrefab, transform);
                        squareGo.transform.position = _pos;
                        continue;
                    }

                    if (height < _grassCount + _dirtCount)
                    {
                        squareGo=Instantiate(_dirtPrefab, transform);
                        squareGo.transform.position = _pos;
                        continue;
                    }
                    squareGo=Instantiate(_stonePrefab, transform);
                    squareGo.transform.position = _pos;
                    
                    

                }
            }
        }
    }

    
}
