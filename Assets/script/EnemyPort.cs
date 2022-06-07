using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPort : MonoBehaviour
{
    //[SerializeField] GameObject Enemy;
    [SerializeField] List<GameObject> EnemyList = new List<GameObject>();
    private Camera _mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        SetNextEnemy();
        GameObject obj = GameObject.Find("Main Camera");
        _mainCamera = obj.GetComponent<Camera>();

        //Debug.Log(getScreenTopLeft().x + ", " + getScreenTopLeft().y);
        //Debug.Log(getScreenBottomRight().x + ":" + getScreenBottomRight().y);
    }

    private Vector3 getScreenTopLeft()
    {
        // 画面の左上を取得
        Vector3 topLeft = _mainCamera.ScreenToWorldPoint(Vector3.zero);
        // 上下反転させる
        topLeft.Scale(new Vector3(1f, -1f, 1f));
        return topLeft;
    }

    private Vector3 getScreenBottomRight()
    {
        // 画面の右下を取得
        Vector3 bottomRight = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        // 上下反転させる
        bottomRight.Scale(new Vector3(1f, -1f, 1f));
        return bottomRight;
    }

    void SetNextEnemy()
    {
        float interval = Random.Range(3f, 5f);
        Invoke("GenerateEnemy", interval);
    }

    //敵を生成する関数
    void GenerateEnemy()
    {
        float x = Random.Range(getScreenTopLeft().x, getScreenBottomRight().x);
        int enemyindex = Random.Range(0, EnemyList.Count);
        GameObject enemy = Instantiate(EnemyList[enemyindex]);
        Vector2 pos = this.transform.position;
        pos.x += x;
        enemy.transform.position = pos;

        //生成した敵の位置を、このEnemyPortの位置に調整
        SetNextEnemy();
    }
}
