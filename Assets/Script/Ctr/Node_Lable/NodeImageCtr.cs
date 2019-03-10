using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeImageCtr : Ictr
{

    public Image ImageSprite;

    private float _ImageMaksValue;

    public float ImageMaksValue
    {
        get { return _ImageMaksValue; }
        set
        {
            _ImageMaksValue = value;
            ImageSprite.material.SetFloat("_ImageMaskValue", value);

        }
    }
    // Start is called before the first frame update
    void Start()
    {

        ImageSprite.material.enableInstancing = true;
        ImageSprite.material.SetFloat("_ImageMaskValue", -0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setMask(float val)
    {
        ImageMaksValue = val;
    }


    public override void Show()
    {
        base.Show();
        Debug.Log("Show");
        Show(setMask, ImageMaksValue,0.5f);

    }

    public override void Hide()
    {
        base.Hide();

        Hide(setMask, ImageMaksValue,0.4f,-0.2f);
    }

}
