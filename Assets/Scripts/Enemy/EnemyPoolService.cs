using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyPoolService
{
    private Dictionary<Enemy, List<Func<bool>>> _pool = new();

    public int EnemiesCountInPool => _pool.Count;

    public void AddEnemy(Enemy enemy, params Func<bool>[] destroyConditions)
    {
        _pool.Add(enemy, destroyConditions.ToList());
    }

    public void Update()
    {
        var enemiesToRemove = _pool
            .Where(pair => pair.Value.Any(condition => condition()))
            .Select(pair => pair.Key)
            .ToList();

        foreach (var enemy in enemiesToRemove)
        {
            enemy.Destroy();
            _pool.Remove(enemy);
        }

        Debug.Log("Enemies count: " + EnemiesCountInPool);
    }

}
