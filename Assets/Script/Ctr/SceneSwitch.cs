using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    public Transform[] SwitchTrans = new Transform[2];
    public Transform bodyTrans;
    public bool EnableKyeCtr;

    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener(EventDefine.GoDefaultScene, goDefaultScene);
        EventCenter.AddListener(EventDefine.GoSoloScene, goSoloScene);
    }

    // Update is called once per frame
    void Update()
    {
        if (EnableKyeCtr)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                EventCenter.Broadcast(EventDefine.GoSoloScene);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                EventCenter.Broadcast(EventDefine.GoDefaultScene);
            }
        }
    }


    private void goDefaultScene() {
        LeanTween.move(bodyTrans.gameObject, SwitchTrans[0].position, 1f).setEase(LeanTweenType.easeInOutQuad);
     
    }

    private void goSoloScene() {
        LeanTween.move(bodyTrans.gameObject, SwitchTrans[1].position, 1f).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.rotateLocal(bodyTrans.gameObject, SwitchTrans[1].localRotation.eulerAngles, 1f).setEase(LeanTweenType.easeInOutQuad);
    }
}
