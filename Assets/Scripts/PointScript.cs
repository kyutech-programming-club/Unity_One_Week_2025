using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;
using TMPro;


public class PointScript : MonoBehaviour
{
    //テキストを表示するUI
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI playertext;
    public TextMeshProUGUI npc1text;
    public TextMeshProUGUI npc2text;
    public Dictionary<string,int> points = new Dictionary<string, int>()
    {
        {"player", 0},
        {"npc1", 0},
        {"npc2", 0},
    };
        public Dictionary<string,TextMeshProUGUI> texts = new Dictionary<string, TextMeshProUGUI>();
    //表示順序
    private string[]displayOrder = new string[] { "player", "npc1", "npc2" };
    // Start is called before the first frame update
    void Start()
    {
        texts =   new Dictionary<string, TextMeshProUGUI>(){
        {"player", playertext},
        {"npc1", npc1text},
        {"npc2", npc2text},
    };
        PlusPoint("npc1", 200);
        PlusPoint("npc2", 100);
        PlusPoint("player", 150);
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



//ポイントを加算する
public void PlusPoint(string key ,int x)
    {
        if(points.ContainsKey(key))
        {
            points[key] += x;
            texts[key].text = key + ":" + points[key].ToString();
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}