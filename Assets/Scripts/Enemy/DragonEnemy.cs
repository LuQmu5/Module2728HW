public class DragonEnemy : Enemy, IEnemy<DragonEnemyConfig>
{
    private uint _dragonArmor;
    private uint _breathesCount;

    public void Init(DragonEnemyConfig config)
    {
        _dragonArmor = config.DragonArmor;
        _breathesCount = config.BreathesCount;
    }
}
