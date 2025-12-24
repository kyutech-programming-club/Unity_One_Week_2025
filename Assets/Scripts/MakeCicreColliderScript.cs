using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeCicreColliderScript : MonoBehaviour
{
    public GameObject spawnPrefab;   // 生成するオブジェクト
    public Transform target;         // 生成位置になるオブジェクト
    public float rotateAngle = 90f;   // 回転角度（Z軸）

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // 回転（Z軸）
            transform.Rotate(0f, 0f, rotateAngle);

            // 生成（target の位置）
            Instantiate(
                spawnPrefab,
                target.position,
                target.rotation
            );

            // 1秒待つ
            yield return new WaitForSeconds(1f);
        }
    }
}
