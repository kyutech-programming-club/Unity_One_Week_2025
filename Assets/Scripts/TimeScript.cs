using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        pointScript = GetComponent<PointScript>();
    }
    public float time;
    private PointScript pointScript;
    public TextMeshProUGUI timeText;
    private bool isFinish;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFinish)return;
        time -= Time.deltaTime;
        timeText.text = time.ToString("N0");
        if (time < 0)
        {
             timeText.text = "";
            isFinish = true;
            pointScript.Finish();
        }
    }
}
