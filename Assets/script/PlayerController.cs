using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    AudioSource BulletSE;
    [SerializeField] GameObject ExplosionEffect;
    [SerializeField] List<GameObject> EnemyList = new List<GameObject>();
    [SerializeField] GameSceneManager mygameManager;
    [SerializeField] float m_speed;
    private Camera _mainCamera;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("ShootS", 0f, 0.3f);
        InvokeRepeating("TripleShoot", 0f, 0.3f);
        BulletSE = GetComponent<AudioSource>();
        GameObject obj = GameObject.Find("Main Camera");
        _mainCamera = obj.GetComponent<Camera>();

        pos = transform.position;

        //GetComponent<Renderer>().material.color = Color.red;
        for (int i = 0; i < EnemyList.Count; i++)
        {
            EnemyList[i].SetActive(true);
        }
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

    // Update is called once per frame
    void Update()
    {
        //透明化
        //GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, -0.001f);   
        //マウスに合わせて飛行機が横に移動
        //transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y);
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        //var velocity = new Vector3(horizontal, vertical) * m_speed;
        //transform.localPosition += velocity;

        transform.position = new Vector2(
            //X座標
            Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, getScreenTopLeft().x, getScreenBottomRight().x),
            //Mathf.Clamp(transform.localPosition.x, getScreenTopLeft().x, getScreenBottomRight().x),
            //Y座標
            Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, getScreenBottomRight().y, getScreenTopLeft().y)
            //Mathf.Clamp(transform.localPosition.y, getScreenBottomRight().y, getScreenTopLeft().y)
            );
    }
    void ShootS()
    {
        GameObject b = Instantiate(bullet); //bulletを生成し、それを"b"という変数に代入
        b.transform.position = transform.position + new Vector3(0f, 0.5f, -1f); //bの位置を自機の中心よりも少し上のところに変更
        Rigidbody2D bulletRigid = b.GetComponent<Rigidbody2D>();
        bulletRigid.AddForce(new Vector2(0f, 200f));

        BulletSE.Play();
    }
    void ShootR()
    {
        GameObject b = Instantiate(bullet); //bulletを生成し、それを"b"という変数に代入
        b.transform.position = transform.position + new Vector3(0f, 0.5f, -1f); //bの位置を自機の中心よりも少し上のところに変更
        Rigidbody2D bulletRigid = b.GetComponent<Rigidbody2D>();
        bulletRigid.AddForce(new Vector2(150f, 200f));
    }
    void ShootL()
    {
        GameObject b = Instantiate(bullet); //bulletを生成し、それを"b"という変数に代入
        b.transform.position = transform.position + new Vector3(0f, 0.5f, -1f); //bの位置を自機の中心よりも少し上のところに変更
        Rigidbody2D bulletRigid = b.GetComponent<Rigidbody2D>();
        bulletRigid.AddForce(new Vector2(-150f, 200f));
    }
    void TripleShoot()
    {
        ShootS();
        ShootR();
        ShootL();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(ExplosionEffect);
        explosion.transform.position = this.transform.position;
        mygameManager.AddScoreToText();
        Destroy(this.gameObject); //自分自身のオブジェクトを消去
        for (int i = 0; i < EnemyList.Count; i++)
        {
            EnemyList[i].SetActive(false);
        }
    }

}
