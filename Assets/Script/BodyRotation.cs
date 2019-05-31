using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotation : MonoBehaviour
{

  //  public GameObject circleLoopGameObj;
    public float speed = 1;

    bool isRoattion = true;

    public SpriteRenderer spriteRender;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener(EventDefine.GoDefaultScene, TurnONRotation);
        EventCenter.AddListener(EventDefine.GoSoloScene, TurnOFFRotation);
        EventCenter.AddListener(EventDefine.GoZongShu, TurnOFFrotation_ShadowRender);

    }

    // Update is called once per frame
    void Update()
    {
        if (isRoattion) {
            transform.Rotate(Vector3.up, 0.1f * speed);
        }
    }

    private void TurnONRotation() {
     //   TurnOnCircleLoop();
        isRoattion = true;
        spriteRender.enabled = true;
    }

    private void TurnOFFRotation()
    {
        isRoattion = false;
        spriteRender.enabled = true;
        //   TurnOffCircleLoop();
    }

    public void TurnOFFrotation_ShadowRender() {
        isRoattion = false;
        spriteRender.enabled = false;
    }

    public void TurnOffCircleLoop() {
  //      circleLoopGameObj.SetActive(false);
    }

    public void TurnOnCircleLoop()
    {
   //     circleLoopGameObj.SetActive(true);
    }
}
