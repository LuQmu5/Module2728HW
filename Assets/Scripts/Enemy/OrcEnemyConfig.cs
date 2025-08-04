using UnityEngine;

[CreateAssetMenu(fileName = "Orc Config", menuName = "StaticData/Configs/Enemies/New Orc Config", order = 54)]
public class OrcEnemyConfig : ScriptableObject, IEnemyConfig
{
    [field: SerializeField] public OrcEnemy Prefab { get; private set; }
    [field: SerializeField] public float CritChance { get; private set; }
    [field: SerializeField] public uint RageCount { get; private set; }

    Enemy IEnemyConfig.Prefab => Prefab;
}
