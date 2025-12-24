using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Linq;

public class NPCScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2D;
    public float power;
    public GameObject targetObj;
    public Dictionary<GameObject, string> pack_action = new Dictionary<GameObject, string>();
    private bool isAttack = false;
    public List<GameObject> targetList;
    private PointScript pointScript;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void FixedUpdate()
    {
        if (isAttack == false)
        {
            Action();
        }
    }
    private void Action()
    {
        if (pack_action.Count == 0) return;
        GameObject pack = pack_action.Keys.First();
        if (pack_action[pack] == "attack1")
        {
            StartCoroutine(Attack1Coroutine(pack));
        }
        if (pack_action[pack] == "attack2")
        {
            StartCoroutine(Attack2Coroutine(pack));
        }
        if (pack_action[pack] == "gard")
        {
            StartCoroutine(GardCoroutine(pack));
        }

        isAttack = true;
    }
    IEnumerator GardCoroutine(GameObject pack)
    {
        Rigidbody2D packRd2D = pack.GetComponent<Rigidbody2D>();
        if (packRd2D == null) yield break;
        Vector3 firstPos = pack.transform.position + (Vector3)packRd2D.velocity * 0.125f;
        // ① 少し上に
        yield return StartCoroutine(MovePos(firstPos, transform.position, 8f, 1f));
        yield return StartCoroutine(MovePos(new Vector3(0, -4, 0), transform.position, 3f, 1f));
        pack_action.Remove(pack);
        isAttack = false;
    }
    IEnumerator Attack1Coroutine(GameObject pack)
    {
        targetObj = targetList[Random.Range(0, 2)];
        Rigidbody2D packRd2D = pack.GetComponent<Rigidbody2D>();
        if (packRd2D == null) yield break;
        Vector3 firstPos = -1 * (targetObj.transform.position - (pack.transform.position + (Vector3)packRd2D.velocity * 0.5f)).normalized * 2 + pack.transform.position + (Vector3)packRd2D.velocity * 0.5f;
        // ① 少し上に
        yield return StartCoroutine(MovePos(firstPos, transform.position, 4f, 0.5f));

        // ② さらに上に
        yield return StartCoroutine(MovePos(pack.transform.position, transform.position, 8f, 1f));

        // ③ 元の位置に戻る
        yield return StartCoroutine(MovePos(new Vector3(0, -4, 0), transform.position, 3f, 1f));
        pack_action.Remove(pack);
        isAttack = false;
    }
    IEnumerator Attack2Coroutine(GameObject pack)
    {
        Rigidbody2D packRd2D = pack.GetComponent<Rigidbody2D>();
        if (packRd2D == null) yield break;
        Vector3 firstPos = pack.transform.position + (Vector3)packRd2D.velocity * 0.125f;
        // ② さらに上に
        yield return StartCoroutine(MovePos(firstPos, transform.position, 8f, 1f));

        // ③ 元の位置に戻る
        yield return StartCoroutine(MovePos(new Vector3(0, -4, 0), transform.position, 3f, 1f));
        pack_action.Remove(pack);
        isAttack = false;

    }
    IEnumerator MovePos(Vector3 finishPos, Vector3 startPos, float speed, float limit)
    {
        float time = 0;
        while (time < 1)
        {
            time += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPos, finishPos, time);
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "pack")
        {
            Rigidbody2D packRd2D = other.gameObject.GetComponent<Rigidbody2D>();
            packRd2D.AddForce((other.transform.position - transform.position).normalized * power, ForceMode2D.Impulse);
        }
    }

}


