using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> packprefabs = new List<GameObject>();
    private List<GameObject> packs = new List<GameObject>();
    public bool isThrow;
    private float span = 1;
    public bool isCheck;
    public bool isMove;
    private int i;
    void FixedUpdate()
    {
        if (isMove == false) return;
        if (isCheck)
        {
            span -= Time.deltaTime;
            transform.position = Vector3.Lerp(new Vector3(0, 9, 0), new Vector3(0, 9, -3), span);
            if (span < 0)
            {
                span = 0;
                isThrow = true;
                isCheck = false;
            }
        }
        else if (isThrow == false)
        {
            if (span < 1)
            {
                span += Time.deltaTime / 3;
                transform.position = Vector3.Lerp(new Vector3(0, 16.23f, 0), new Vector3(0, 16.23f, -5), span);
            }
            else
            {
                isMove = false;
                span = 1;
                transform.position = Vector3.Lerp(new Vector3(0, 16.23f, 0), new Vector3(0, 16.23f, -5), span);
            }
        }
        if (isThrow)
        {
            span += Time.deltaTime;
            if (span > 1)
            {
                span = 0;
                if (packs.Count > 0)
                {
                    Instantiate(packs[0], new Vector3(0, 15, 0), Quaternion.identity);
                    packs.Remove(packs[0]);

                }
                else
                {
                    int R = Random.Range(0, 3);
                    for (int j = 0; j < 5 + R; j++)
                    {
                        packs.Add(packprefabs[Random.Range(0, 3)]);
                    }
                    isThrow = false;
                }
            }
        }
    }
    void Start()
    {
        int R = Random.Range(0, 3);
        for (int j = 0; j < 1; j++)
        {
            packs.Add(packprefabs[Random.Range(0, 3)]);
        }
    }

}
