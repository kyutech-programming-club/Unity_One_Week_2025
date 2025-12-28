using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;
using System.Linq;
using TMPro;
using unityroom.Api;

public class PointScript : MonoBehaviour
{
    //テキストを表示するUI
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI playertext;
    public TextMeshProUGUI npc1text;
    public TextMeshProUGUI npc2text;
    public Dictionary<string, int> points = new Dictionary<string, int>()
    {
        {"player", 0},
        {"npc1", 0},
        {"npc2", 0},
    };
    public Dictionary<string, TextMeshProUGUI> texts = new Dictionary<string, TextMeshProUGUI>();
    //表示順序
    private string[] displayOrder = new string[] { "player", "npc1", "npc2" };
    public List<TextMeshProUGUI> ranking = new List<TextMeshProUGUI>();
    private PointScript pointScript;
    private AudioSource audioSource;
    public AudioSource finishAudio;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pointScript = FindAnyObjectByType<PointScript>();
        texts = new Dictionary<string, TextMeshProUGUI>(){
        {"player", playertext},
        {"npc1", npc1text},
        {"npc2", npc2text},
    };
        // PlusPoint("npc1", 200);
        // PlusPoint("npc2", 100);
        // PlusPoint("player", 150);
        // foreach (var point in points)
        // {
        //     Debug.Log(point.Key + ": " + point.Value);
        // }
        // Finish();

    }
    public GameObject UI;
    public void Finish()
    {
        finishAudio.Play();
        UI.SetActive(true);

        var sorted = points
            .OrderByDescending(x => x.Value)
            .ToList(); // ← 明示的に List 化（安全）

        for (int i = 0; i < ranking.Count && i < sorted.Count; i++)
        {
            string name = "";
            if (sorted[i].Key == "player")
            {
                name = "赤プレイヤー";
            }
            else if (sorted[i].Key == "npc1")
            {
                name = "緑プレイヤー";
            }
            else if (sorted[i].Key == "npc2")
            {
                name = "青プレイヤー";
            }
            ranking[i].text = $"{name} ";
            Debug.Log($"{i + 1}位 {sorted[i].Key} : {sorted[i].Value}");
            if (isRule && sorted[i].Key == "player")
            {
                UnityroomApiClient.Instance.SendScore(1, sorted[i].Value, ScoreboardWriteMode.HighScoreDesc);
            }
        }
    }

    public SlopeScript slopeScript;


    //ポイントを加算する
    public bool isRule;
    private bool isFinish;
    public void PlusPoint(string key, int x)
    {

        if (isFinish == true) return;
        audioSource.Play();
        if (isRule)
        {
            if (points.ContainsKey(key))
            {
                points[key] += x;
                texts[key].text = points[key].ToString();
            }
        }
        else
        {
            if (points.ContainsKey(key))
            {

                points[key] += x;
                texts[key].text = points[key].ToString();
                if (points[key] > 4)
                {
                    isFinish = true;
                    pointScript.Finish();
                }
                else
                {
                    slopeScript.isCheck = true;
                    slopeScript.isMove = true;
                }

            }
        }

    }
    // Update is called once per frame
}