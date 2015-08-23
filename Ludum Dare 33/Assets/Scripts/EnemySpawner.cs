#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private Spawnable[] _spawns;

    public float MaxSpawnY, MinSpawnY, MaxSpawnX, MinSpawnX;

    private struct SpawnPrevalence
    {
        public Spawnable Spawn;
        public float Prevalence;
    }

    public GameObject GetSpawnable(float height)
    {
        float prevalenceSum = 0;

        List<SpawnPrevalence> prevalenceList = new List<SpawnPrevalence>();

        foreach (Spawnable s in _spawns)
        {
            float prevalence = s.Prevalence.Evaluate(height);
            SpawnPrevalence sp = new SpawnPrevalence { Spawn = s, Prevalence = prevalence };
            prevalenceList.Add(sp);
            prevalenceSum += prevalence;
        }

        prevalenceList.Sort(new PrevalenceComparer());
        float testedPrevalence = 0;
        float random = UnityEngine.Random.Range(0, prevalenceSum);
        Spawnable spawn = null;
        foreach (SpawnPrevalence sp in prevalenceList)
        {
            testedPrevalence += sp.Prevalence;
            if (random > testedPrevalence) continue;
            spawn = sp.Spawn;
            break;
        }
        if(spawn == null)
        {
            Debug.LogError("No spawn selected. Tested prevalence: " + testedPrevalence + ". Prevalence sum: " + prevalenceSum);
            return null;
        }
        return spawn.gameObject;
    }

    public void Spawn(Vector2 position)
    {
        float height = normalizeHeight(position.y);
        GameObject spawn = GetSpawnable(height);
        Instantiate(spawn, position, Quaternion.identity);
    }

    private float normalizeHeight(float height)
    {
        return (height - MinSpawnY) / (MaxSpawnY - MinSpawnY);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(new Vector2(MinSpawnX, MaxSpawnY), new Vector2(MaxSpawnX, MaxSpawnY));
        Gizmos.DrawLine(new Vector2(MinSpawnX, MinSpawnY), new Vector2(MaxSpawnX, MinSpawnY));
    }

    private class PrevalenceComparer : Comparer<SpawnPrevalence>
    {
        public override int Compare(SpawnPrevalence x, SpawnPrevalence y)
        {
            return x.Prevalence.CompareTo(y.Prevalence);
        }
    }

}
#pragma warning restore 0649
