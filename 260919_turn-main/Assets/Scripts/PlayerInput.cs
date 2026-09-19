using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private LayerMask _rayTargetLayer;
    
    private Camera _camera;
    
    private static PlayerInput _instance;
    public static PlayerInput Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerInput>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        SetSingleton();
        CacheComponents();
    }
    private void OnDestroy() => _instance = null;

    public Unit GetUnit()
    {
        Unit unit = null;
        Ray  ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 15f, _rayTargetLayer))
        {
            unit = hit.collider.GetComponent<Unit>();
        }
        
        return unit;
    }
    
    private void SetSingleton()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    
    private void CacheComponents()
    {
        _camera = Camera.main;
    }
}
