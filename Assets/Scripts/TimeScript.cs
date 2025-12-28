using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    public SlopeScript slopeScript;
    public void IsRule_true()
    {
        isrule = true;
        pointScript.isRule = true;
        slopeScript.isrule = true;
    }
    public void IsRule_false()
    {
        isrule = false;
        pointScript.isRule = false;
        slopeScript.isrule = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        pointScript = FindAnyObjectByType<PointScript>();
        timeText = GetComponent<TextMeshProUGUI>();
        slopeScript.isCheck = true;
        slopeScript.isMove = true;
    }
    public float time;
    private PointScript pointScript;
    public TextMeshProUGUI timeText;
    private bool isFinish;
    private bool isAction;
    public bool isrule;
    public bool isStart;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isStart == false) return;
        if (isFinish) return;
        if (isrule)
        {
            time -= Time.deltaTime;
            timeText.text = time.ToString("N0");
            if ((int)time % 15 == 1 && isAction == false)
            {
                isAction = true;
                slopeScript.isCheck = true;
                slopeScript.isMove = true;
            }
            if (isAction && (int)time % 15 == 2)
            {
                isAction = false;
            }
            if (time < 0)
            {
                timeText.text = "";
                isFinish = true;
                pointScript.Finish();
            }
        }
        else
        {

        }
    }
}
