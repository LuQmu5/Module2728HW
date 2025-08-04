using UnityEngine;

[CreateAssetMenu(fileName = "Elf Config", menuName = "StaticData/Configs/Enemies/New Elf Config", order = 54)]
public class ElfEnemyConfig : ScriptableObject, IEnemyConfig
{
    [field: SerializeField] public ElfEnemy Prefab { get; private set; }
    [field: SerializeField] public uint Mana { get; private set; }
    [field: SerializeField] public float EvasionChance { get; private set; }

    Enemy IEnemyConfig.Prefab => Prefab;
}
