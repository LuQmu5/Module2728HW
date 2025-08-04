using UnityEngine;

public class EnemiesTest : MonoBehaviour
{
    [Header("Configs")]
    [SerializeField] private OrcEnemyConfig[] _orcEnemiesConfigs;
    [SerializeField] private ElfEnemyConfig[] _elfEnemiesConfigs;
    [SerializeField] private DragonEnemyConfig[] _dragonEnemiesConfigs;

    private EnemyPoolService _enemyPoolService;
    private EnemySpawner _enemySpawner;

    public void Init(EnemyPoolService enemyPoolService)
    {
        _enemyPoolService = enemyPoolService;

        _enemySpawner = new EnemySpawner();
    }

    private void Update()
    {
        _enemyPoolService.Update();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            foreach (var config in _orcEnemiesConfigs)
            {
                Enemy enemy = _enemySpawner.GetEnemy<OrcEnemy, OrcEnemyConfig>(config);
                _enemyPoolService.AddEnemy(enemy, () => enemy.IsDead);
            }
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            foreach (var config in _elfEnemiesConfigs)
            {
                Enemy enemy = _enemySpawner.GetEnemy<ElfEnemy, ElfEnemyConfig>(config);
                float creationTime = Time.time;
                float destructionTime = 5;

                _enemyPoolService.AddEnemy(enemy, () => Time.time - creationTime > destructionTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            foreach (var config in _dragonEnemiesConfigs)
            {
                Enemy enemy = _enemySpawner.GetEnemy<DragonEnemy, DragonEnemyConfig>(config);
                int enemiesLimit = 5;
                _enemyPoolService.AddEnemy(enemy, () => _enemyPoolService.EnemiesCountInPool > enemiesLimit);
            }
        }
    }
}
