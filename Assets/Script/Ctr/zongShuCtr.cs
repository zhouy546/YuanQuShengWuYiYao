using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zongShuCtr : Ictr
{
  public   Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener(EventDefine.GoDefaultScene, Hide);
        EventCenter.AddListener(EventDefine.GoSoloScene, Hide);
        EventCenter.AddListener(EventDefine.GoZongShu, Show);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Hide()
    {
        base.Hide();
        animator.SetBool("Show", false);
    }

    public override void Show()
    {
        base.Show();
        animator.SetBool("Show", true);
    }
}
