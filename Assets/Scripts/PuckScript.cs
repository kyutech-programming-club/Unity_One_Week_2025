using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PuckScript : MonoBehaviour
{
    public GameObject puckPrefab;

    public Vector3 spawnPosition;
    void Start()
    {
        SpawnPuck(0,0,0);
    }

    public void SpawnPuck(int spawnPosition_x, int spawnPosition_y, int spawnPosition_z)
    { 
        spawnPosition = new Vector3(spawnPosition_x, spawnPosition_y, spawnPosition_z);
        if (puckPrefab != null)
        {
            Instantiate(puckPrefab,spawnPosition,Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Prefabが設定されていません！");
        }      
    }
}
