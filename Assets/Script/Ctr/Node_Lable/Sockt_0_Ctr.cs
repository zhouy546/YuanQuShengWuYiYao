using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sockt_0_Ctr : Ictr
{

    public MeshRenderer meshRenderer;

    private float _ballOpacity;
    public float BallOpacity {
        get { return _ballOpacity; }
        set {
            _ballOpacity = value;
            meshRenderer.material.SetFloat("_Opacity", value);
        }
    }


    public bool EnableKyeCtr = false;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer.material.SetFloat("_Opacity", 0f);
        setOpacity(meshRenderer.material.GetFloat("_Opacity"));
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

    void setOpacity(float val)
    {
        BallOpacity = val;
    }


    public override void Hide()
    {
        base.Hide();

        Hide(setOpacity, BallOpacity);
    }

    public override void Show()
    {
        base.Show();
        Show(setOpacity, BallOpacity);
    }
}
