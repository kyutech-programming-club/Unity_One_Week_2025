using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Linq;

public class NPCScript : MonoBehaviour
{
    public GameObject Npc;
    private Rigidbody2D rigidbody2D;
    private GameObject pack;
    public float circleR;
    public float speed;
    private Vector3 startpos;
    void Start()
    {
        rigidbody2D = Npc.GetComponent<Rigidbody2D>();
        startpos = Npc.transform.position;

    }

    void FixedUpdate()
    {
        if (pack != null)
        {
            rigidbody2D.velocity = (pack.transform.position - Npc.transform.position).normalized * speed;
            if ((pack.transform.position - transform.position).magnitude > circleR)
            {
                pack = null;
            }
        }
        else
        {
            Vector2 nextPos = Vector2.MoveTowards(
    rigidbody2D.position,
    startpos,
    speed * Time.fixedDeltaTime
);

            rigidbody2D.MovePosition(nextPos);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.transform.tag == "pack" && pack == null)
        {
            pack = other.gameObject;
        }
    }

    // Start is called before the first frame update
}
