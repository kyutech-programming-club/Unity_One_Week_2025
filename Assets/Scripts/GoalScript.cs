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
            PackScript packScript = other.GetComponent<PackScript>();
            string kickerKey = packScript.lastOwnerKey;
            string pointer = packScript.pointer;
            string keeperKey = ownerOfThisGoal.ToString();
            Debug.Log(pointer + ":" + kickerKey + ":" + pointer);
            if (kickerKey == keeperKey)
            {
                if (pointer != "")
                    PointScript.PlusPoint(pointer, 100);
                PointScript.PlusPoint(keeperKey, -50);
            }
            else if (keeperKey == pointer)
            {

                PointScript.PlusPoint(keeperKey, -50);
                if (kickerKey != "")
                    PointScript.PlusPoint(kickerKey, 100);
            }
            else
            {
                PointScript.PlusPoint(kickerKey, 100);
            }
        }
    }
    private GameObject othObj;
    private void OnCollisionEnter2D(Collision2D other)
    {
        PackScript lastOwnerKey = other.gameObject.GetComponent<PackScript>();
        //オブジェクトがpackタグを持っているか確認
        if (other.gameObject.CompareTag("pack"))
        {
            if (othObj != null && othObj == other.gameObject)
            {
                return;
            }
            PackScript packScript = other.gameObject.GetComponent<PackScript>();
            othObj = other.gameObject;
            // string kickerKey = packScript.lastOwnerKey;
            // string pointer = packScript.pointer;
            string keeperKey = ownerOfThisGoal.ToString();
            if (keeperKey == "player")
            {
                PointScript.PlusPoint("npc1", packScript.point);
                PointScript.PlusPoint("npc2", packScript.point);
                PointScript.PlusPoint("player", -packScript.point);
            }
            if (keeperKey == "npc1")
            {
                PointScript.PlusPoint("npc1", -packScript.point);
                PointScript.PlusPoint("npc2", packScript.point);
                PointScript.PlusPoint("player", packScript.point);
            }
            if (keeperKey == "npc2")
            {
                PointScript.PlusPoint("npc1", packScript.point);
                PointScript.PlusPoint("npc2", -packScript.point);
                PointScript.PlusPoint("player", packScript.point);
            }
            // if (kickerKey == keeperKey)
            // {
            //     if (pointer != "")
            //         PointScript.PlusPoint(pointer, packScript.point);
            //     PointScript.PlusPoint(keeperKey, -packScript.point / 2);
            // }
            // else if (keeperKey == pointer)
            // {

            //     PointScript.PlusPoint(keeperKey, -packScript.point / 2);
            //     if (kickerKey != "")
            //         PointScript.PlusPoint(kickerKey, packScript.point);
            // }
            // else
            // {
            //     PointScript.PlusPoint(kickerKey, packScript.point);
            //     PointScript.PlusPoint(keeperKey, -packScript.point / 2);
            // }
            Destroy(other.gameObject);
        }
    }
}
