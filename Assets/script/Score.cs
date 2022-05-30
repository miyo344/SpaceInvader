using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text UIText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UIText.text = "Score: " + GameSceneManager.Score.ToString();
        //UIText.text = GameSceneManager.Score.ToString();
    }
}
