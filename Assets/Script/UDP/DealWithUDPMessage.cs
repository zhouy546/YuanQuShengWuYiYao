
//*********************❤*********************
// 
// 文件名（File Name）：	DealWithUDPMessage.cs
// 
// 作者（Author）：			LoveNeon
// 
// 创建时间（CreateTime）：	Don't Care
// 
// 说明（Description）：	接受到消息之后会传给我，然后我进行处理
// 
//*********************❤*********************

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;

public class DealWithUDPMessage : MonoBehaviour {


    public static DealWithUDPMessage instance;
    // public GameObject wellMesh;
    private string dataTest;
    // public static char[] sliceStr;

    private string PerviousKey = "null";

    private int CountDownTime = 180;
    private int CurrenCountDownTime;
    //private static bool isInScreenProtect=true;


    //public LogoWellCtr logoWellCtr;
    //private bool enterTrigger, exitTrigger;
    /// <summary>
    /// 消息处理
    /// </summary>
    /// <param name="_data"></param>
    public void MessageManage(string _data)
    {
        if (_data != "")
        {


            dataTest = _data;

            Debug.Log(dataTest);



            if (dataTest == "2025")
            {//返回默认
                EventCenter.Broadcast<string>(EventDefine.GoDefaultUDP, dataTest);
            }

           

            else if (ValueSheet.UDP_CanvasNodeCtrPair.ContainsKey(dataTest))//进入单个
            {
               // Debug.Log(ValueSheet.UDP_CanvasNodeCtrPair.ContainsKey(dataTest));
               EventCenter.Broadcast<string>(EventDefine.GOSoloSceneUDP,dataTest);
            

            }


        }
    }

    public IEnumerator CountDown() {
        yield return new WaitForSeconds(1);
        CurrenCountDownTime--;
        if (CurrenCountDownTime == 0) {
            string s = "2025";
            EventCenter.Broadcast<string>(EventDefine.GoDefaultUDP, s);
            CurrenCountDownTime = CountDownTime;
        }
        StartCoroutine(CountDown());
    }


    private void Awake()
    {
        CurrenCountDownTime = CountDownTime;

    }

    public IEnumerator Initialization() {
        if (instance == null)
        {
            instance = this;
        }
        yield return new  WaitForSeconds(0.01f);
    }

    public void Start()
    {
        EventCenter.AddListener<string>(EventDefine.GoDefaultUDP, toDefaultScene);
        EventCenter.AddListener<string>(EventDefine.GOSoloSceneUDP,toSoloScene);
        StartCoroutine(CountDown());
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) {
            Debug.Log(ValueSheet.UDP_CanvasNodeCtrPair.ContainsKey("10001"));
        }

        //Debug.Log("数据：" + dataTest);  
    }

    public void toDefaultScene(string key) {
        Debug.Log(key);
        EventCenter.Broadcast(EventDefine.GoDefaultScene);
        if(PerviousKey != "null")
        {
            ValueSheet.UDP_CanvasNodeCtrPair[PerviousKey].Hide();
        }
        PerviousKey = "null";
    }

    public void toSoloScene(string key) {
        CurrenCountDownTime = CountDownTime;
        EventCenter.Broadcast(EventDefine.GoSoloScene);

        if (PerviousKey != "null")
        {
            ValueSheet.UDP_CanvasNodeCtrPair[PerviousKey].Hide();
        }

        ValueSheet.UDP_CanvasNodeCtrPair[key].Show();
        PerviousKey = key;
    } 

}
