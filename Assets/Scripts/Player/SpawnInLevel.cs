using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnInLevel : MonoBehaviour
{
    [SerializeField] private GameObject spawn; // Reference to the spawn point
    private void Awake()
    {
        if (spawn != null)
        {
            // Set this object's position to the spawn point's position
            transform.position = spawn.transform.position;
        }
        else
        {
            Debug.LogWarning("Spawn point is not assigned in the Inspector!");
        }
    }
}
