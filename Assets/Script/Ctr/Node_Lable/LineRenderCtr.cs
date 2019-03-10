using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderCtr : Ictr
{
    public List<Transform> SocketTransforms=new List<Transform>();
    public LineRenderer lineRenderer;

    private float _LineMoveValue;
    
    public float LineMoveValue {
        get{ return _LineMoveValue; }
        set {
            _LineMoveValue = value;
            lineRenderer.material.SetFloat("_LineMoveValue", value);
          
        }
    }

    public bool EnableKyeCtr = false;

    // Start is called before the first frame update
    void Start()
    {

        lineRenderer.material.SetFloat("_LineMoveValue", 0f);
        setOpacity(lineRenderer.material.GetFloat("_LineMoveValue"));
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in SocketTransforms)
        {
            lineRenderer.SetPosition(SocketTransforms.IndexOf(item), item.position);
        }

        if (EnableKyeCtr) {
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




    void setOpacity(float val) {
        LineMoveValue = val;
    }


    public override void Hide()
    {
        base.Hide();

        Hide(setOpacity, LineMoveValue,0.8f);
    }

    public override void Show()
    {
        base.Show();

        Show(setOpacity, LineMoveValue);
    }

}
