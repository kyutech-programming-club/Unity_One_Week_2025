using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackScript : MonoBehaviour
{
    //最後に所有していたプレイヤーのキー
    public string lastOwnerKey = "";
    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerIDScript p = collision.gameObject.GetComponent<PlayerIDScript>();
        if (p != null)
        {
            lastOwnerKey = p.lastname.ToString();
        }
    }
}
