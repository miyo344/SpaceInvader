using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text UIText;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            UIText.text = "Score: " + GameSceneManager.Score.ToString();
        }
    }

    //public void ScoreText()
    //{
    //    Debug.Log("テスト");
    //    if (player != null)
    //    {
    //        UIText.text = "Score: " + GameSceneManager.Score.ToString();
    //    }
    //}
}
