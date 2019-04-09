using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class CanvasNodeCtr : Ictr
{
    public Image[] CanvasImages = new Image[4];
    public PlayableDirector playableDirector;
    public PlayableAsset[] playableAssets = new PlayableAsset[2];

    public int id;
    public bool EnableKyeCtr = false;

    public CanvasNode canvasNode;
    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnableKyeCtr)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Show();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                Hide();
            }
        }
    }

    public override void Hide()
    {
        base.Hide();
        playableDirector.Play(playableAssets[1]);
    }

    public override void Show()
    {
        base.Show();
        playableDirector.Play(playableAssets[0]);
        SocketRender.instance.enableOneDisableOther(id);
    }

    public void ini(int index)
    {
        for (int i = 0; i < CanvasImages.Length; i++)
        {
            //Debug.Log(index);
            Sprite sp = ValueSheet.canvasGroupSprites[index][i];

            LoadImage(sp, CanvasImages[i]);
        }


    }

    private void LoadImage(Sprite sprite,Image NodeImage)
    {
        NodeImage.sprite = sprite;

        NodeImage.SetNativeSize();
        //setNodeImageScale(sprite, NodeImage);
    }

    private void setNodeImageScale(Sprite sprite,Image NodeImage)
    {
        NodeImage.rectTransform.sizeDelta = new Vector2(NodeImage.rectTransform.rect.width, CalcuateHeight(sprite,NodeImage));
        //  MaskImage.rectTransform.sizeDelta = new Vector2(NodeImage.rectTransform.rect.width, CalcuateHeight(sprite));

    }

    private float CalculateWidth(Sprite sprite, Image NodeImage)
    {
        float temp;
        temp = NodeImage.rectTransform.rect.height * sprite.rect.width / sprite.rect.height;
        return temp;
    }

    private float CalcuateHeight(Sprite sprite, Image NodeImage)
    {
        float temp;
        temp = NodeImage.rectTransform.rect.width * sprite.rect.height / sprite.rect.width;
        Debug.Log(temp);

        return temp;
    }
}
