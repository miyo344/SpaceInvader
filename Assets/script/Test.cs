using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<int> mylist = new List<int>(); //mylistは色んな数字を格納するリスト
        mylist.Add(20); //mylistに20を追加
        mylist.Add(40); //mylistに40を追加
        mylist.Add(30); //mylistに30を追加
        mylist.Add(50); //mylistに50を追加
        //foreach(int list in mylist)
        //{
        //    if(list > 25)
        //    {
        //        Debug.Log(list);
        //    }
        //}
        for(int i= 0; i < mylist.Count; i++)
        {
            if(mylist[i] > 25)
            {
                Debug.Log(mylist[i]);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
