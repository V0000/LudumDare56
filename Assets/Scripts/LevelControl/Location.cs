using UnityEngine;

public class Location : MonoBehaviour
{
    public CloneSpawner cloneSpawner;
    public ObjectDestroyer destination;
    public int goal;
    
    public void Reload()
    {
        ClearLevel();
        cloneSpawner.SpawnHero();
    }

    public void ClearLevel()
    {
        foreach (var clone in cloneSpawner.clones)
        {
            Destroy(clone);
        }
        CommandLogger.Commands.Clear();
        Destroy(cloneSpawner.heroInstance);
    }
}
