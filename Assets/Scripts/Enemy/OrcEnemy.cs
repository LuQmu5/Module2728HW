public class OrcEnemy : Enemy, IEnemy<OrcEnemyConfig>
{
    private float _critChance;
    private uint _rageCount;

    public void Init(OrcEnemyConfig config)
    {
        _critChance = config.CritChance;
        _rageCount = config.RageCount;
    }
}
