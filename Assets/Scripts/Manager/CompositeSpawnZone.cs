using UnityEngine;

public class CompositeSpawnZone : MonoBehaviour
{
    [SerializeField]
    SpawnZone[] SpawnZones;

    public Vector3 SpawnPoint()
    {
        int index = Random.Range(0, SpawnZones.Length);
        SpawnZone SelectedZone = SpawnZones[index];
        return SelectedZone.SpawnPoint;
    }
}

