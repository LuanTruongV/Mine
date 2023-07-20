using System;
using UnityEngine;

namespace Prefabs
{
    public class Create : MonoBehaviour
    {
        [SerializeField] private GameObject _squareSelected;
        [SerializeField] private Square _grass;
        [SerializeField] private GameObject _init;

        private float _size;
        private void Start()
        {
        }

        public void Init()
        {
            _init.SetActive(true);
        }
        public void Change(Transform pos,Vector3 direc)
        {
            if (_init.activeSelf == false)
            {
                _init.SetActive(true);
            }
            _init.transform.position = pos.parent.position + direc * _grass.transform.localScale.x;
        }

        public void CreateSquare()
        {
            if (_init.activeSelf == true)
            {
                if (_squareSelected != null)
                {
                    Debug.Log(_squareSelected.name);
                    Instantiate(_squareSelected, _init.transform.position,Quaternion.identity);
                }
            }
            _init.SetActive(false);
        }

        public void UnInit()
        {
            _init.SetActive(false);
        }

        public void SelectSquare(GameObject squarePrefab)
        {
            _squareSelected = squarePrefab;
        }
            
    }
}