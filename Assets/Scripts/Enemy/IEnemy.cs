public interface IEnemy<in TConfig> where TConfig : IEnemyConfig
{
    void Init(TConfig config);
}
