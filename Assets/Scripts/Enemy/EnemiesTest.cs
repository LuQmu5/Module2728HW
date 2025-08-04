using UnityEngine;

public class EnemiesTest : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    private EnemyPoolService _enemyPoolService;

    public void Init(EnemyPoolService enemyPoolService)
    {
        _enemyPoolService = enemyPoolService;
    }

    private void Update()
    {
        _enemyPoolService.Update();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Enemy enemy = Instantiate(_enemyPrefab);
            _enemyPoolService.AddEnemy(enemy, () => enemy.IsDead);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Enemy enemy = Instantiate(_enemyPrefab);
            float creationTime = Time.time;
            float destructionTime = 5;

            _enemyPoolService.AddEnemy(enemy, () => Time.time - creationTime > destructionTime);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Enemy enemy = Instantiate(_enemyPrefab);
            int enemiesLimit = 5;
            _enemyPoolService.AddEnemy(enemy, () => _enemyPoolService.EnemiesCountInPool > enemiesLimit);
        }
    }
}
