using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Node_LableCtr : Ictr
{
    public NodeType nodeType;

    public Animator animator;

    public PlayableDirector playableDirector;

    public PlayableAsset[] playableAssets = new PlayableAsset[2];

    public Image NodeImage;

    public float MinAngle=-33f, MaxAngle=9f;

    public Transform SocketTransform;
    //public Image MaskImage;
    // Start is called before the first frame update

    public bool EnableKyeCtr = false;

    private bool isInDefaultScene= true;

    private bool isenable = false;

    void Start()
    {
        EventCenter.AddListener(EventDefine.GoSoloScene, TURNOFFdefaultScene);
        EventCenter.AddListener(EventDefine.GoZongShu, TURNOFFdefaultScene);
        EventCenter.AddListener(EventDefine.GoDefaultScene, TURNONdefaultScene);

        //  RotationMySelf();
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

        updatePosition(SocketTransform);
    }

    public void updatePosition(Transform SocketTrans) {
        this.transform.position = SocketTrans.position;
    }

    private void TURNONdefaultScene() {
        isInDefaultScene = true;

        if (checkCurrentRot()) {
            Show();
        }
    }

    bool checkCurrentRot() {
        //  Debug.Log("running" + this.transform.localRotation.eulerAngles.y);


        if (nodeType == NodeType.LeftNode)
        {
            float val = this.transform.localRotation.eulerAngles.y;
            if (val > MinAngle && val < MaxAngle)
            {
                return true;
            }
            else {
                return false;
            }

        }
        else if (nodeType == NodeType.RightNode) {
            float val = Mathf.Sin(Mathf.Deg2Rad * (this.transform.localRotation.eulerAngles.y));

            if (val > Mathf.Sin(Mathf.Deg2Rad * MinAngle) && val < Mathf.Sin(Mathf.Deg2Rad * MaxAngle))
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }

    private void TURNOFFdefaultScene() {
        Hide();
        isInDefaultScene = false;

    }


    public override void Show()
    {
        base.Show();
        if (isInDefaultScene)
        {

            if (isenable == false) {
                playableDirector.Play(playableAssets[0]);
                isenable = true;
            }

        }
    }

    public override void Hide()
    {
        base.Hide();
        if (isInDefaultScene)
        {
            if (isenable == true)
            {
                playableDirector.Play(playableAssets[1]);

                isenable = false;
            }
        }
    }

    public void ini(Sprite sprite) {
        LoadImage(sprite);
    }


    private void  LoadImage(Sprite sprite) {
        NodeImage.sprite = sprite;

        setNodeImageScale(sprite);
    }

    private void setNodeImageScale(Sprite sprite) {
        NodeImage.rectTransform.sizeDelta = new Vector2(NodeImage.rectTransform.rect.width, CalcuateHeight(sprite));
      //  MaskImage.rectTransform.sizeDelta = new Vector2(NodeImage.rectTransform.rect.width, CalcuateHeight(sprite));

    }

    private float CalculateWidth(Sprite sprite) {
        float temp;
        temp = NodeImage.rectTransform.rect.height * sprite.rect.width / sprite.rect.height;
        return temp;
    }

    private float CalcuateHeight(Sprite sprite) {
        float temp;
        temp = NodeImage.rectTransform.rect.width * sprite.rect.height / sprite.rect.width;
        Debug.Log(temp);

        return temp;
    }
}
