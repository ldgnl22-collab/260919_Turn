using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoint;
    
    private List<Unit> _playerUnits = new List<Unit>();
    private List<Unit> _monsterUnits = new List<Unit>();
    
    private void Start() => Init();
    
    

    private void Init()
    {
        foreach (Unit unit in GameManager.Instance.PlayerParty)
        {
            _playerUnits.Add(Instantiate(unit));
        }

        foreach (Unit unit in GameManager.Instance.MonsterParty)
        {
            _monsterUnits.Add(Instantiate(unit));
        }

        for (int i = 0; i < _playerUnits.Count; i++)
        {
            // 0, 1, 2
            _playerUnits[i].transform.position = _spawnPoint[i].position;
        }

        for (int i = 0; i < _monsterUnits.Count; i++)
        {
            // 3, 4, 5
            _monsterUnits[i].transform.position = _spawnPoint[i + 3].position;
        }
    }

}
