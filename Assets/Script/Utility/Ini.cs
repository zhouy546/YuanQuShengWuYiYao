﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Ini : MonoBehaviour {
    private ReadJson readJson;

    private BannerCtr bannerCtr;

    private CanvasGroupCtr canvasGroupCtr;

    private void  Start() {
         StartCoroutine(initialization());
    }

    IEnumerator initialization()
    {
        bannerCtr = FindObjectOfType<BannerCtr>();

        readJson = FindObjectOfType<ReadJson>();

        canvasGroupCtr= FindObjectOfType<CanvasGroupCtr>();
        //------------------------------------------------------

        yield return StartCoroutine(readJson.initialization());

        yield return StartCoroutine(ReadAssetImage());

        canvasGroupCtr.ini();

        bannerCtr.ini();

        EventCenter.Broadcast(EventDefine.GoZongShu);

    }

    IEnumerator ReadAssetImage()
    {
        yield return StartCoroutine(BannerNodeSprites());

        yield return StartCoroutine(CanvasGroupSprite());
    }


    //IEnumerator ReadDescription()
    //{
    //    for (int i = 0; i < ValueSheet.NodeList.Count; i++)
    //    {
    //        List<Sprite> sp = new List<Sprite>();
    //        string path = "/UI/Description/" + i.ToString() + "/";
    //        // Debug.Log(path);
    //        yield return GetSpriteListFromStreamAsset(path, "png", sp);

    //        ValueSheet.DescriptionkeyValuePairs.Add(i, sp);
    //    }

    //    //  Debug.Log(ValueSheet.DescriptionkeyValuePairs.Count);
    //}



    IEnumerator CanvasGroupSprite() {
        for (int i = 0; i < ValueSheet.canvasNodes.Count; i++)
        {

            List<Sprite> CanvasGroupSpritesTemp = new List<Sprite>();
            string path = "/UI/CanvasNodes/"+(i+1).ToString()+"/";

            yield return StartCoroutine( GetSpriteListFromStreamAsset(path, "png", CanvasGroupSpritesTemp));

            ValueSheet.canvasGroupSprites.Add(CanvasGroupSpritesTemp);

            //Debug.Log(ValueSheet.canvasGroupSprites.Count);
            //Debug.Log(ValueSheet.canvasGroupSprites[i].sprites.Count);
        }
    }

    IEnumerator BannerNodeSprites()
    {
        string path = "/UI/NodeImageSprites/";
        yield return GetSpriteListFromStreamAsset(path, "png", ValueSheet.BannerNodeSprites);
    }

  

    IEnumerator GetSpriteListFromStreamAsset(string path, string suffix, List<Sprite> sprites)
    {
        List<Texture> texturesList = new List<Texture>();
        string streamingPath = Application.streamingAssetsPath + path;
        DirectoryInfo dir = new DirectoryInfo(streamingPath);

        GetAllFiles(dir, path, suffix);

        foreach (string de in jpgName)
        {
            WWW www = new WWW(Application.streamingAssetsPath + path + de);
            yield return www;
            if (www != null)
            {
                Texture texture = www.texture;
                texture.name = de;
                texturesList.Add(texture);
            }
            if (www.isDone)
            {
                www.Dispose();
            }
        }

        foreach (var texture in texturesList)
        {
            Sprite sprite = Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            sprite.name = texture.name;
            sprites.Add(sprite);
        }

        jpgName.Clear();
    }

    List<string> jpgName = new List<string>();

    public void GetAllFiles(DirectoryInfo dir, string Filepath, string suffix)
    {
        FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();   //初始化一个FileSystemInfo类型的实例
        foreach (FileSystemInfo i in fileinfo)              //循环遍历fileinfo下的所有内容
        {
            if (i is DirectoryInfo)             //当在DirectoryInfo中存在i时
            {
                GetAllFiles((DirectoryInfo)i, Filepath, suffix);  //获取i下的所有文件
            }
            else
            {
                string str = i.FullName;        //记录i的绝对路径
                string path = Application.streamingAssetsPath + Filepath;
                string strType = str.Substring(path.Length);

                if (strType.Substring(strType.Length - 3).ToLower() == suffix)
                {
                    if (jpgName.Contains(strType))
                    {
                    }
                    else
                    {
                        jpgName.Add(strType);
                    }
                }
            }
        }
    }
}
