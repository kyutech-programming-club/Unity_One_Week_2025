using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    public PointScript PointScript;
    public PlayerIDScript.PlayerName ownerOfThisGoal;
    // public string targetTag = "player";
    // Start is called before the first frame update
    void Start()
    {
        PointScript = FindAnyObjectByType<PointScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PackScript lastOwnerKey = other.GetComponent<PackScript>();
        //オブジェクトがpackタグを持っているか確認
        if (other.CompareTag("pack"))
        {
            
            string kickerKey = other.GetComponent<PackScript>().lastOwnerKey;
            string keeperKey= ownerOfThisGoal.ToString();
            if (kickerKey == keeperKey)
            {
                PointScript.PlusPoint(kickerKey, -100);
            }
            else
            {
                PointScript.PlusPoint(kickerKey, 100);
            }
        }
    }
}
