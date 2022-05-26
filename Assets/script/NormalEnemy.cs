using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    [SerializeField] float ActiveTime = 5f;
    [SerializeField] public float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject ExplosionEffect;
    [SerializeField] int score;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyMyself", ActiveTime);

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        InvokeRepeating("ShootS", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyMyself()
    {
        GameObject explosion = Instantiate(ExplosionEffect);
        explosion.transform.position = this.transform.position;
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(ExplosionEffect);
        explosion.transform.position = this.transform.position;
        //GameSceneManager.Score++;
        GameSceneManager.Score += score;
        Destroy(this.gameObject); //自分自身のオブジェクトを消去
    }
    void ShootS()
    {
        GameObject b = Instantiate(bullet); //bulletを生成し、それを"b"という変数に代入
        b.transform.position = transform.position + new Vector3(0f,-0.5f, -1f); //bの位置を自機の中心よりも少し上のところに変更
        Rigidbody2D bulletRigid = b.GetComponent<Rigidbody2D>();
        bulletRigid.AddForce(new Vector2(0f, -200f));
    }
}
