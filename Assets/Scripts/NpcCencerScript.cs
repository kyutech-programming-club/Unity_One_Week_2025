using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NpcCencerScript : MonoBehaviour
{
    public NPCScript nPCScript;
    public string roll;

    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.transform.tag == "pack")
        // {
        //     Dictionary<GameObject, string> packs = nPCScript.pack_action;
        //     if (!packs.ContainsKey(other.gameObject))
        //     {
        //         nPCScript.pack_action.Add(other.transform.gameObject, roll);

        //     }
        // }
    }
}
