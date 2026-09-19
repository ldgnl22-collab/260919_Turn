using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMonster : MonoBehaviour
{
    private Party _party;
    
    private void Awake() => CacheComponents();
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Party player = other.GetComponent<Party>();
            
            GameManager.Instance.SetBattleData(player, _party);
            GameManager.Instance.StartBattle();
        }
    }
    
    private void CacheComponents()
    {
        _party = GetComponent<Party>();
    }
}







