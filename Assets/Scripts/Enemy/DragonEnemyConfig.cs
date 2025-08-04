using UnityEngine;

[CreateAssetMenu(fileName = "Dragon Config", menuName = "StaticData/Configs/Enemies/New Dragon Config", order = 54)]
public class DragonEnemyConfig : ScriptableObject, IEnemyConfig
{
    [field: SerializeField] public DragonEnemy Prefab { get; private set; }
    [field: SerializeField] public uint DragonArmor { get; private set; }
    [field: SerializeField] public uint BreathesCount { get; private set; }

    Enemy IEnemyConfig.Prefab => Prefab;
}