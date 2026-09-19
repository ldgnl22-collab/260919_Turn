using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMonsterCharacter : MonoBehaviour
{
    private BattleModule _module;
    private Phase _selectAttackPhase;

    private void Awake()
    {
        CacheComponents();
        Init();
    }

    private void Init()
    {
        _selectAttackPhase = new Phase();
        _selectAttackPhase.OnPhaseRunning.AddListener(Attack);
        _selectAttackPhase.FinishDelay = 2f;
        _selectAttackPhase.Init();
        
        _module.AddPhase(_selectAttackPhase);
    }

    private void Attack()
    {
        Unit target = SelectPlayerCharacter();
        
        BattleManager.Instance.Attack(target);
        Debug.Log($"{gameObject.name} : {target.name}에게 공격");
        _selectAttackPhase.IsFinished = true;
    }

    private Unit SelectPlayerCharacter()
    {
        // 플레이어 체력이 모두 같지 않다면 체력이 가장 적은 캐릭터를 타겟
        int minHealth = BattleManager.Instance.PlayerUnits[0].Health;
        Unit target = null;
        
        for (int i = 1; i < BattleManager.Instance.PlayerUnits.Count; i++)
        {
            if (minHealth > BattleManager.Instance.PlayerUnits[i].Health)
            {
                target = BattleManager.Instance.PlayerUnits[i];
            }
        }

        // 체력이 모두 같다면 랜덤 선택
        if (target == null)
        {
            int max = BattleManager.Instance.PlayerUnits.Count;
            int index = Random.Range(0, max);
            
            target = BattleManager.Instance.PlayerUnits[index];
        }
        
        return target;
    }

    private void CacheComponents()
    {
        _module = GetComponent<BattleModule>();
    }
}