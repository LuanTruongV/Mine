using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private Chunk _chunkPrefabs;
    [SerializeField] private int _size;

    private void Start()
    {
        Gerenal();
    }

    private void Gerenal()
    {
        float sizeChunk = _chunkPrefabs.Size;
        float athwart = (float)Mathf.Abs(_size%2 - 1) / 2;
        for (int width = 0; width < _size; width++)
        {
            for (int length = 0; length < _size; length++)
            {
                float x = transform.position.x-_size/2+width+athwart;
                float z = transform.position.z-_size/2+length+athwart;
                Vector3 pos = new Vector3(x * sizeChunk, transform.position.y, z * sizeChunk);
                GameObject chunk=Instantiate(_chunkPrefabs.gameObject, transform);
                chunk.transform.position = pos;
            }
        }
    }
}