using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Time.timeScale = 0;
    }
    public void GmaeStart()
    {
        Time.timeScale = 1;
        StartCoroutine(LowerZ(500, 2f));

    }

    // Update is called once per frame

    IEnumerator LowerZ(float amount, float time)
    {
        Vector3 start = transform.position;
        Vector3 end = start + new Vector3(0, -amount, 0);

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / time;
            transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }
    }

}
