using UnityEngine;

public class EnemySpawner
{
    public TEnemy GetEnemy<TEnemy, TConfig>(TConfig config)
        where TEnemy : Enemy, IEnemy<TConfig>
        where TConfig : ScriptableObject, IEnemyConfig
    {
        var enemy = Object.Instantiate((TEnemy)config.Prefab);
        enemy.Init(config);
        return enemy;
    }
}
