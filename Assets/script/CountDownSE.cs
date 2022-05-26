using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownSE : MonoBehaviour
{
    [SerializeField] Text UIText;
    AudioSource CountSE;
    // Start is called before the first frame update
    void Start()
    {
        CountSE = GetComponent<AudioSource>();
        CountSE.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
