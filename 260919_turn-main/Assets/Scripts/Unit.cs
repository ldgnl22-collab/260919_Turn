using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [field: SerializeField] public int Health { get; private set; }
    [field: SerializeField] public float Speed {  get; private set; }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        IPoolable poolable = UIPool.Instance.Take();
        
        if (poolable is DamageUI ui)
        {
            ui.SetData(damage);
            ui.Tr.position = transform.position;
        }
        
        if (Health <= 0)
        {
            BattleManager.Instance.Die(this);
        }
    }
}
