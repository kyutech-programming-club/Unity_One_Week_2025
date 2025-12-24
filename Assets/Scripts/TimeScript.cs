using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeScript : MonoBehaviour
{
    public SlopeScript slopeScript;
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
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFinish) return;
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
}
