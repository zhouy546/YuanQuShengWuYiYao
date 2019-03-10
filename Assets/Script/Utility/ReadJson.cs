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


        //for (int i = 0; i < itemDate["information"].Count; i++)

        //{
        //    SetupNodeList(i, ref ValueSheet.NodeList,"information");

        //}

        //for (int i = 0; i < itemDate["Intro"].Count; i++)

        //{
        //    SetupNodeList(i, ref ValueSheet.Intro_NodeList, "Intro");
        //}

        //for (int i = 0; i < itemDate["Strategy"].Count; i++)
        //{
        //    SetupNodeList(i, ref ValueSheet.strategy_NodeList, "Strategy");

        //}



 

        //ValueSheet.BGMVolume = float.Parse(itemDate["Setup"][0]["BGMVolume"].ToString());
        //ValueSheet.MainVideoUrl =itemDate["Setup"][0]["MainVideUrl"].ToString();

      

    }

    //void SetupNodeList(int i, ref List<Node> nodes,string SectionStr)
    //{
    //    int id;
    //    string bigTitle;
    //    string VideoPath;

    //    id = int.Parse(itemDate[SectionStr][i]["id"].ToString());//get id;

    //    bigTitle = itemDate[SectionStr][i]["BigTitle"].ToString();//get bigtitle;

    //    VideoPath = itemDate[SectionStr][i]["VideoPath"].ToString();//get video path;

    //    nodes.Add(new Node(id, bigTitle, VideoPath));
    //}
}
