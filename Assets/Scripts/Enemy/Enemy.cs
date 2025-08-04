using UnityEngine;

public class Enemy : MonoBehaviour, IDiable
{
    public bool IsDead { get; private set; }

    [ContextMenu("Kill Enemy")]
    public void Kill() => IsDead = true;

    public void Destroy()
    {
        gameObject.SetActive(false);
        Debug.Log($"Enemy {gameObject.name} died");
    }
}
