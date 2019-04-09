using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasNodeCircleCtr : Ictr
{
    public Animator animator;
    public bool EnableKyeCtr = false;
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
        animator.SetTrigger("Hide");
    }

    public override void Show()
    {
        base.Show();
        animator.SetTrigger("Show");
    }
}
