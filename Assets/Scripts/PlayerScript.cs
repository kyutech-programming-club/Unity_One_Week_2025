using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Camera mainCamera;
    public float slowScale = 0.2f;   // スロー時の時間倍率
    public float normalScale = 1f;   // 通常
    public bool hold = true;
    private float fixedZ;//プレイヤーのZ座標を保持する変数
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        fixedZ = transform.position.z;//初期のZ座標を保存
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if (hold)
        // {
        //     if (Input.GetMouseButton(0))
        //         Time.timeScale = slowScale;
        //     else
        //         Time.timeScale = normalScale;
        // }
        // // クリックしたら切り替え
        // else
        // {
        //     if (Input.GetMouseButtonDown(0))
        //     {
        //         Time.timeScale =
        //             Time.timeScale == normalScale ? slowScale : normalScale;
        //     }
        // }
        if (transform.position.x < -2.5)
        {
            transform.position = new Vector3(-2.5f, transform.position.x, 0f);
        }
        if (transform.position.x > 2.5)
        {
            transform.position = new Vector3(2.5f, transform.position.x, 0f);
        }
        //マウスの位置を取得
        Vector3 mousePos = Input.mousePosition;
        //Z座標をカメラからの距離に設定
        mousePos.z = Mathf.Abs(mainCamera.transform.position.z - fixedZ);//カメラからの距離を計算
        //スクリーン座標をワールド座標に変換
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);
        if (worldPos.x < -2.5 || worldPos.x < -2.5 || worldPos.y < -1.2) return;
        //Rigidbodyを使ってプレイヤーを移動
        Vector3 targetPos = new Vector3(worldPos.x, worldPos.y, fixedZ);
        //プレイヤーを目標位置に移動
        rb.MovePosition(targetPos);

    }
}
