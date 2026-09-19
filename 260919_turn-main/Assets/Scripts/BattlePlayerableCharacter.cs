using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayerableCharacter : MonoBehaviour
{
    private BattleModule _module;
    
    private Phase _playerSelectPhase;
    private Phase _damagePhase;

    private Unit _targetMonster;

    private void Awake()
    {
        CacheComponents();
        Init();
    }
    
    private void CacheComponents()
    {
        _module = GetComponent<BattleModule>();
    }
    
    private void Init()
    {
        _playerSelectPhase = new Phase();
        _playerSelectPhase.OnPhaseRunning.AddListener(SelectMonster);
        _playerSelectPhase.FinishDelay = 1f;
        _playerSelectPhase.Init();
        
        _damagePhase =  new Phase();
        _damagePhase.OnPhaseRunning.AddListener(Attack);
        _damagePhase.FinishDelay = 2f;
        _playerSelectPhase.Init();
        
        _module.AddPhase(_playerSelectPhase);
        _module.AddPhase(_damagePhase);
        
        // _module.AddPhase(_playerSelectionPhase,  _damagePhase);
    }

    private void Attack()
    {
        BattleManager.Instance.Attack(_targetMonster);
        _damagePhase.IsFinished = true;
        Debug.Log($"{gameObject.name} : {_targetMonster.name}를 공격");
    }

    private void SelectMonster()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        
        Unit unit = PlayerInput.Instance.GetUnit();

        if (unit == null) return;
        
        _targetMonster = unit;
        _playerSelectPhase.IsFinished = true;
        Debug.Log($"{gameObject.name} : {_targetMonster.name}를 타겟으로 지정");
    }
}
