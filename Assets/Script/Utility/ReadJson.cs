using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using System.IO;

using LitJson;

using UnityEngine.UI;

public class ReadJson : MonoBehaviour {


    public static ReadJson instance;

  //  public  Ntext ntext;

    private JsonData itemDate;

    private string jsonString;

    public CanvasGroupCtr canvasGroupCtr;

    public IEnumerator initialization() {
        if (instance == null)
        {

            instance = this;

        }

     yield return   StartCoroutine(readJson());
    }

    IEnumerator readJson() {
        string spath = Application.streamingAssetsPath + "/information.json";

        Debug.Log(spath);

        WWW www = new WWW(spath);

        yield return www;

        jsonString = System.Text.Encoding.UTF8.GetString(www.bytes);

        JsonMapper.ToObject(www.text);

       itemDate = JsonMapper.ToObject(jsonString.ToString());


        for (int i = 0; i<itemDate["information"].Count; i++)
        {
            SetupCanvasNodeList(i, ref ValueSheet.canvasNodes, "information");
        }


        //setNode
        foreach (CanvasNodeCtr ctr in canvasGroupCtr.canvasNodeCtrs)
        {
            int num = canvasGroupCtr.canvasNodeCtrs.IndexOf(ctr);

            ctr.canvasNode = ValueSheet.canvasNodes[num];
        }


        //setDictionary
        foreach (CanvasNodeCtr ctr in canvasGroupCtr.canvasNodeCtrs)
        {
            ValueSheet.UDP_CanvasNodeCtrPair.Add(ctr.canvasNode.UDP, ctr);
        }



        //ValueSheet.BGMVolume = float.Parse(itemDate["Setup"][0]["BGMVolume"].ToString());
        //ValueSheet.MainVideoUrl =itemDate["Setup"][0]["MainVideUrl"].ToString();

        foreach (var item in ValueSheet.UDP_CanvasNodeCtrPair)
        {
            Debug.Log("key_:"+item.Key);

            Debug.Log("ID_:" + item.Value.canvasNode.id);
        }

    }

    void SetupCanvasNodeList(int i, ref List<CanvasNode> nodes, string SectionStr)
    {
        int id;
        string UDP;

        id = int.Parse(itemDate[SectionStr][i]["id"].ToString());//get id;

        UDP = itemDate[SectionStr][i]["UDP"].ToString();//get video path;

        nodes.Add(new CanvasNode(id,  UDP));
    }
}
