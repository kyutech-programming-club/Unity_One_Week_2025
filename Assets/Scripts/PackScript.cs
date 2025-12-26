using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PackScript : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private CircleCollider2D circleCollider2D;
    public SpriteRenderer spriteRenderer;
    public int point;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }
    private bool isMove;
    void FixedUpdate()
    {
        if (isMove == false)
        {
            transform.position -= new Vector3(0, 0.4f, 0);
            if (transform.position.y < 4f)
            {
                circleCollider2D.isTrigger = false;
                isMove = true;
                Debug.Log("False");
                rigidbody2D.velocity = new Vector2(0, -2);
                spriteRenderer.sortingOrder = 5;
            }
        }
    }
    //最後に所有していたプレイヤーのキー
    public string lastOwnerKey = "";
    public string pointer = "";
    private List<string> names = new List<string>();
    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
        if (collision.transform.tag != "wall" && collision.transform.tag != "pack")
        {
            PlayerIDScript p = collision.gameObject.GetComponent<PlayerIDScript>();
            if (p != null)
            {
                string key = p.lastname.ToString();
                if(names.Contains(key) == false)
                {
                    if(names.Count > 1)
                    {
                        names.Remove(names[0]);
                    }
                    names.Add(key);
                    lastOwnerKey = names[0];
                    if(names.Count  >=  2)
                    {
                        pointer = names[1];
                    }
                    Debug.Log("Last Owner: " + lastOwnerKey + " Pointer: " + pointer);
                }
            }
        }
    }
}
