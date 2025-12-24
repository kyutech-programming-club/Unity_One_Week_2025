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
// }
//     private Rigidbody2D rigidbody2D;
//     public float power;
//     public GameObject targetObj;
//     public Dictionary<GameObject, string> pack_action = new Dictionary<GameObject, string>();
//     private bool isAttack = false;
//     public List<GameObject> targetList;
//     private PointScript pointScript;
//     private Vector3 StaticPos;
//     public float npcSpeed = 1f;
//     void Start()
//     {
//         rigidbody2D = GetComponent<Rigidbody2D>();
//         StaticPos = transform.position;
//     }
//     public void FixedUpdate()
//     {
//         if (isAttack == false)
//         {
//             Action();
//         }
//     }
//     private void Action()
//     {
//         if (pack_action.Count == 0) return;
//         GameObject pack = pack_action.Keys.First();
//         if (pack_action[pack] == "attack1")
//         {
//             StartCoroutine(Attack1Coroutine(pack));
//         }
//         if (pack_action[pack] == "attack2")
//         {
//             StartCoroutine(Attack2Coroutine(pack));
//         }
//         if (pack_action[pack] == "gard")
//         {
//             StartCoroutine(GardCoroutine(pack));
//         }

//         isAttack = true;
//     }
//     IEnumerator GardCoroutine(GameObject pack)
//     {
//         Rigidbody2D packRd2D = pack.GetComponent<Rigidbody2D>();
//         if (packRd2D == null) yield break;
//         Vector3 firstPos = pack.transform.position + (Vector3)packRd2D.velocity * (1 / npcSpeed);
//         // ① 少し上に
//         yield return StartCoroutine(MovePos(firstPos, transform.position, npcSpeed, 1f));
//         yield return StartCoroutine(MovePos(StaticPos, transform.position, 3f, 1f));
//         pack_action.Remove(pack);
//         isAttack = false;
//     }
//     IEnumerator Attack1Coroutine(GameObject pack)
//     {
//         targetObj = targetList[Random.Range(0, 2)];
//         Rigidbody2D packRd2D = pack.GetComponent<Rigidbody2D>();
//         if (packRd2D == null) yield break;
//         Vector3 firstPos = -1 * (targetObj.transform.position - (pack.transform.position + (Vector3)packRd2D.velocity * (1 / npcSpeed))).normalized * 2 + pack.transform.position + (Vector3)packRd2D.velocity * (1 / npcSpeed);
//         Vector3 pos = pack.transform.position + (Vector3)packRd2D.velocity * (1 / npcSpeed);
//         // ① 少し上に
//         yield return StartCoroutine(MovePos(firstPos, transform.position, npcSpeed, 1f));

//         // ② さらに上に
//         yield return StartCoroutine(MovePos(pos, transform.position, npcSpeed, 3f));

//         // ③ 元の位置に戻る
//         targetObj = null;
//         yield return StartCoroutine(MovePos(StaticPos, transform.position, 3f, 10f));
//         pack_action.Remove(pack);
//         isAttack = false;

//     }
//     IEnumerator Attack2Coroutine(GameObject pack)
//     {
//         Rigidbody2D packRd2D = pack.GetComponent<Rigidbody2D>();
//         if (packRd2D == null) yield break;
//         Vector3 firstPos = pack.transform.position + (Vector3)packRd2D.velocity * (1 / npcSpeed);
//         // ② さらに上に
//         yield return StartCoroutine(MovePos(firstPos, transform.position, npcSpeed, 3f));

//         // ③ 元の位置に戻る
//         yield return StartCoroutine(MovePos(StaticPos, transform.position, 3f, 10f));
//         pack_action.Remove(pack);
//         isAttack = false;

//     }
//     // IEnumerator MovePos(Vector3 finishPos, Vector3 startPos, float speed, float limit)
//     // {
//     //     float time = 0;
//     //     while (time < 1)
//     //     {
//     //         time += Time.deltaTime * speed;
//     //         transform.position = Vector3.Lerp(startPos, finishPos, time);
//     //         yield return null;
//     //     }
//     // }
//     IEnumerator MovePos(
//         Vector3 finishPos,
//         Vector3 startPos,
//         float speed,
//         float limit
//     )
//     {
//         float t = 0f;

//         while (t < 1f)
//         {
//             float dist = Vector3.Distance(transform.position, startPos);
//             if (dist >= limit) break;

//             t += Time.fixedDeltaTime * speed;
//             rigidbody2D.MovePosition(Vector3.Lerp(startPos, finishPos, t));

//             yield return new WaitForFixedUpdate();
//         }
//     }

//     private void OnCollisionEnter2D(Collision2D other)
//     {
//         if (other.transform.tag == "pack")
//         {
//             Rigidbody2D packRd2D = other.gameObject.GetComponent<Rigidbody2D>();
//             if (targetObj != null)
//             {
//                 packRd2D.AddForce((targetObj.transform.position - transform.position).normalized * power, ForceMode2D.Impulse);
//             }
//             else
//             {
//                 packRd2D.AddForce((other.transform.position - transform.position).normalized * power, ForceMode2D.Impulse);
//             }
//         }
//     }


