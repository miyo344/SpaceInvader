using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float ActiveTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyMyself",ActiveTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyMyself()
    {
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject); //自分自身のオブジェクトを消去
    }
}
