using UnityEngine;
using NativeWebSocket;
using System.Text;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
[System.Serializable]
public class JsonData
{
    public string type;
    public string role;
    public string content;
    public string roomname;
}
public class Blue_Green_PosData
{
    public string roomname;
    public Vector2 r;
    public Vector2 g;
    public Vector2 b;
    public Vector2 p;
    public Vector2 s;
}
public class Red_posDate
{
    public string roomname;
    public string role;
    public Vector2 pos;

}
public class WSClient : MonoBehaviour
{
    public List<GameObject> rgbp;
    WebSocket ws;
    private bool isOnece;
    public string roomname;
    public TMP_InputField _inputField;

    public void InputName()
    {
        roomname = _inputField.text;
        Debug.Log(roomname);
    }
    private string role = "";
    public List<GoalScript> goalScripts;
    public SlopeScript slopeScript;
    public GameObject UI;
    public GameObject packPrefab;
    private Rigidbody2D rigidbody2D;
    public async void MultiStart()
    {
        foreach (GoalScript goalScript in goalScripts)
        {
            goalScript.isMulti = true;
        }
        slopeScript.isMulti = true;
        if (isOnece == false) isOnece = true;
        ws = new WebSocket("ws://192.168.0.9:8080");

        ws.OnOpen += () =>
        {
            Debug.Log("WebSocket Connected");
            JsonData data = new JsonData();
            data.type = "0";
            data.role = role;
            data.content = "";

            string json = JsonUtility.ToJson(data, true);
            Send(roomname);
        };

        ws.OnMessage += (bytes) =>
        {
            string msg = Encoding.UTF8.GetString(bytes);
            Debug.Log("Received: " + msg);
            rgbp[2] = Instantiate(packPrefab, new Vector3(-0.303909302f, 4.45999956f, 0.00999999046f), Quaternion.identity);
            if (rigidbody2D == null)
            {
                rigidbody2D = rgbp[2].gameObject.GetComponent<Rigidbody2D>();
            }
            rigidbody2D.AddForce(new Vector2(Random.Range(-2, 2), Random.Range(-2, 2)), ForceMode2D.Impulse);
            if (msg == "r")
            {
                role = "r";
            }
            else if (msg == "b")
            {
                role = "b";
            }
            else if (msg == "g")
            {
                role = "g";
            }
            else
            {
                if (role == "r")
                {
                    Red_posDate data = JsonUtility.FromJson<Red_posDate>(msg);
                    if (data.role == "g")
                    {
                        rgbp[1].transform.position = data.pos;
                    }
                    if (data.role == "b")
                    {
                        rgbp[2].transform.position = data.pos;
                    }
                }
                if (role == "b")
                {
                    Blue_Green_PosData data = JsonUtility.FromJson<Blue_Green_PosData>(msg);
                    rgbp[0].transform.position = data.r;
                    rgbp[1].transform.position = data.g;
                    rgbp[3].transform.position = data.p;
                    rgbp[4].transform.position = data.s;
                }
            }
        };

        ws.OnError += (e) =>
        {
            Debug.LogError("WS Error: " + e);
        };

        ws.OnClose += (e) =>
        {
            Debug.Log("WebSocket Closed");
        };

        await ws.Connect();
    }

    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        ws?.DispatchMessageQueue();
        if (role == "R")
        {
            Blue_Green_PosData pos = new Blue_Green_PosData
            {
                roomname = roomname,
                r = rgbp[0].transform.position,
                g = rgbp[1].transform.position,
                b = rgbp[2].transform.position,
                p = rgbp[3].transform.position
            };
            JsonData data = new JsonData
            {
                type = "1",
                role = "R",
                content = JsonUtility.ToJson(pos, true)
            };

            string json = JsonUtility.ToJson(data, true);
            Send(json);
        }
        // else if()
#endif
    }

    public async void Send(string message)
    {
        Debug.Log("Send called: " + message);

        if (ws == null)
        {
            Debug.LogError("ws is null");
            return;
        }

        Debug.Log("WS State: " + ws.State);

        if (ws.State == WebSocketState.Open)
        {
            await ws.SendText(message);
            Debug.Log("SendText awaited");
        }
        else
        {
            Debug.LogWarning("WebSocket not open");
        }
    }


    async void OnDestroy()
    {
        if (ws != null)
            await ws.Close();
    }
}
