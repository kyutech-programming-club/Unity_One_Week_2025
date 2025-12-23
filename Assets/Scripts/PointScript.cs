using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;


public class PointScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlusPoint("npc1", 200);
        PlusPoint("npc2", 100);
        // foreach (var point in points)
        // {
        //     Debug.Log(point.Key + ": " + point.Value);
        // }
        // Finish();

    }
    public void Finish()
    {
        var sortedByKey = points.OrderBy(pair => pair.Key);

        Debug.Log("Sorted by Key:");
        foreach (var kvp in sortedByKey)
        {
            Debug.Log($"{kvp.Key} : {kvp.Value}");
        }
    }

public Dictionary<string,int> points = new Dictionary<string, int>()
{
    {"player", 0},
    {"npc1", 0},
    {"npc2", 0},
};



public void PlusPoint(string key ,int x)
    {
        points[key] += x;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
