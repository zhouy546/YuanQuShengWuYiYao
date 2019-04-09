using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotation : MonoBehaviour
{

  //  public GameObject circleLoopGameObj;
    public float speed = 1;

    bool isRoattion = true;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener(EventDefine.GoDefaultScene, TurnONRotation);
        EventCenter.AddListener(EventDefine.GoSoloScene, TurnOFFRotation);

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
    }

    private void TurnOFFRotation()
    {
        isRoattion = false;
     //   TurnOffCircleLoop();
    }

    public void TurnOffCircleLoop() {
  //      circleLoopGameObj.SetActive(false);
    }

    public void TurnOnCircleLoop()
    {
   //     circleLoopGameObj.SetActive(true);
    }
}
