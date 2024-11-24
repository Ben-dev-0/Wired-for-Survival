using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class SpawnerScript : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int spawnCount = 0;
    public int minSpawnCount = 3;
    public int maxSpawnCount = 6;

    public float delay = 2f;
    public float targetTime;     
    [SerializeField] private GameObject interactionPrompt; 

    [SerializeField] private float activationDistance = 7f;  

    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");

        if (player == null)
        {
            Debug.Log("Player GameObject not found!");
        }

        targetTime = delay;
        //enemyPrefab = Resources.Load<GameObject>("prefabs/enemy");
        if(enemyPrefab == null)
        {
            Debug.LogError("enemy prefab not found");
        }
    }

    public void Spawn()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        spawnCount++;
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            Debug.Log(gameObject.name +" "+ distance);

            if (distance <= activationDistance)
            {
                targetTime -= Time.deltaTime;
                if (spawnCount < minSpawnCount)
                {
                    Spawn();

                }

                else if (spawnCount < maxSpawnCount && targetTime <= 0f)
                {
                    Spawn();
                    targetTime = delay;
                }
            }
        }
    }
}
