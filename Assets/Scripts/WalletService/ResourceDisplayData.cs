using UnityEngine;

[CreateAssetMenu(fileName = "Resource Display Data", menuName = "StaticData/Configs/Resources/New Resource Display Data", order = 54)]
public class ResourceDisplayData : ScriptableObject
{
    [field: SerializeField] public ResourceType Type { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
}