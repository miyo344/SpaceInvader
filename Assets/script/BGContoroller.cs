using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGContoroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
        if (transform.position.y <= -11f)
        {
            ResetPosition();
        }
    }

    void Scroll()
    {
        Vector2 pos = transform.position;
        pos.y -= 0.01f;
        transform.position = pos;
    }

    void ResetPosition()
    {
        Vector2 pos = transform.position;
        pos.y += 30f;
        transform.position = pos;
    }
}
