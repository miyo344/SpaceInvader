using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingEnemy : MonoBehaviour
{
    [SerializeField] float ActiveTime = 5f;

    [SerializeField] public float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject ExplosionEffect;
    [SerializeField] int score;
    private Rigidbody2D rb;
    private GameObject player;

    void Start()
    {
        Invoke("DestroyMyself", ActiveTime);

        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        InvokeRepeating("Shoot", 0.5f, 2f);
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
        GameSceneManager.Score += score;
        Destroy(this.gameObject);
    }

    void Shoot()
    {
        if (player != null)
        {
            GameObject b = Instantiate(bullet);
            b.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
            Rigidbody2D bulletRigid = b.GetComponent<Rigidbody2D>();
            Vector2 target = player.transform.position - this.transform.position;  //targetという変数（弾を発射するべき方向のベクトルを代入）を初期化
            bulletRigid.velocity = target; //bulletRigidの速度に代入することで発射
            bulletRigid.velocity /= 2f; //このままだと弾が速すぎるので速度を半分に変更
        }
    }
}
