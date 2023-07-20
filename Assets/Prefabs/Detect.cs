using System;
using System.Collections;
using System.Collections.Generic;
using Prefabs;
using UnityEngine;
using UnityEngine.EventSystems;

public class Detect : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance = 20f;
    [SerializeField] private LayerMask _detecLayer;
    [SerializeField] private Create _create;
    private Square _detectedSquare;

    private void Start()
    {
        _detectedSquare = null;
    }

    private void Update()
    {
        if(EventSystem. current.IsPointerOverGameObject())
        {
            if (_detectedSquare != null)
            {
                _detectedSquare.UnDetect();
            }
            return;
        }
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit,_maxDistance,_detecLayer ))
        {
            DetectSquare(hit);
            DestroySquare();
            CreateInput(hit);
        }
        else
        {
            if (_detectedSquare != null)
            {
                _detectedSquare.UnDetect();
            }
            _create.UnInit();
        }
        
    }

    private void DestroySquare()
    {
        if (_detectedSquare != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _detectedSquare.Destroy();
            }
        }
    }

    private void DetectSquare(RaycastHit hit)
    {
        if (_detectedSquare == null || _detectedSquare.gameObject != hit.transform.gameObject)
        {
            if (_detectedSquare != null)
            {
                _detectedSquare.UnDetect();
            }

            _detectedSquare = hit.transform.parent.gameObject.GetComponent<Square>();
            _detectedSquare.Detect();
        }
    }

    private void CreateInput(RaycastHit hit)
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (_detectedSquare != null)
            {
                _detectedSquare.UnDetect();
            }
            _create.Init();
        }

        if (Input.GetMouseButton(1))
        {
            if (_detectedSquare != null)
            {
                _detectedSquare.UnDetect();
            }
            _create.Change(hit.transform, hit.normal.normalized);
        }

        if (Input.GetMouseButtonUp(1))
        {
            
            _create.CreateSquare();
        }
    }
}