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
    public string pointer;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "wall")
        {
            PlayerIDScript p = collision.gameObject.GetComponent<PlayerIDScript>();
            if (p != null)
            {
                if (lastOwnerKey == p.lastname.ToString())
                {
                    pointer = p.lastname.ToString();
                }
                else if (pointer != p.lastname.ToString())
                {
                    lastOwnerKey = p.lastname.ToString();
                }
            }
        }
    }
}
