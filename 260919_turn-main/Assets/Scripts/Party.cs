using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    // 파티에 소속된 캐릭터들 정보
    // 배틀 시스템쪽으로 정보 전달
    [field: SerializeField] public Unit[] Units { get; private set; }
}
