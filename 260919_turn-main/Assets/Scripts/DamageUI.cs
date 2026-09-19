using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using Unity.VisualScripting;
using System;

public class DamageUI : MonoBehaviour, IPoolable
{
    [SerializeField] private Vector3 _maxForce;
    [SerializeField] private float _returnDelay;
    
    private WaitForSeconds _returnDelayWait;
    private Rigidbody _rigidbody;
    private Camera _camera;
    private TextMeshProUGUI _tmp;
    
    public Transform Tr { get => transform; }
    
    // 일정시간 이후 풀로 반납(비활성화)
    
    private void Awake()
    {
        CacheComponents();
        Init();
    }
    
    private void OnEnable()
    {
        AddRandomForce();
        StartCoroutine(ReturnRoutine());
    }
    
    private void LateUpdate() => SetRotate();

    private IEnumerator ReturnRoutine()
    {
        yield return _returnDelayWait;
        Return();
    }
    
    public void Return()
    {
        gameObject.SetActive(false);
    }

    public void SetData(int value)
    {
        _tmp.text = value.ToString();
    }

    private void Init()
    {
        _returnDelayWait = new WaitForSeconds(_returnDelay);
    }

    private void SetRotate()
    {
        transform.forward = _camera.transform.forward;
    }

    private void AddRandomForce()
    {
        _rigidbody.velocity = GetRandomForce();
    }

    private Vector3 GetRandomForce()
    {
        return new Vector3(
            Random.Range(-_maxForce.x, _maxForce.x),
            _maxForce.y,
            Random.Range(-_maxForce.z, _maxForce.z)
        );
    }
    
    private void CacheComponents()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _tmp = GetComponentInChildren<TextMeshProUGUI>();
        _camera = Camera.main;
    }
}
