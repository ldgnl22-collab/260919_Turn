using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMovement : MonoBehaviour
{
    // 1. WASD 이동
    //    - 속도는 인스펙터에서 조절할 수 있도록 노출
    // 2. 'Player' 태그로 설정
    [SerializeField] private float _moveSpeed;

    private void Update() => Tick();
    
    private void Tick()
    {
        Vector3 movement = ReadMovement().normalized;
        
        transform.Translate(movement *  _moveSpeed * Time.deltaTime, Space.World);
    }

    private Vector3 ReadMovement()
    {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
    }

}
