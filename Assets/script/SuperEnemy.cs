using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperEnemy : MonoBehaviour
{
    [SerializeField] float ActiveTime = 5f;

    [SerializeField] public float speed = 1f;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject ExplosionEffect;
    [SerializeField] int score;
    private Rigidbody2D rb;

    void Start()
    {
        Invoke("DestroyMyself", ActiveTime);

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
        //GameSceneManager.Score++;
        GameSceneManager.Score += score;
        Destroy(this.gameObject);
    }

    void Shoot()
    {
        //今からここを埋めていくよ
        for (int i =  -100; i <=  100; i +=  50)
        {
            GameObject b = Instantiate(bullet);
            b.transform.position = transform.position + new Vector3(0f, -0.5f, 0f);
            Rigidbody2D bulletRigid = b.GetComponent<Rigidbody2D>();
            bulletRigid.AddForce(new Vector2(i, -100f));
        }
    }
}
