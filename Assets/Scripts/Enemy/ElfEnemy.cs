public class ElfEnemy : Enemy, IEnemy<ElfEnemyConfig>
{
    private uint _mana;
    private float _evasionChance;

    public void Init(ElfEnemyConfig config)
    {
        _mana = config.Mana;
        _evasionChance = config.EvasionChance;
    }
}
