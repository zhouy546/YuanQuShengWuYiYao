using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleNodeCtr : MonoBehaviour
{

    public List<MeshRenderer> meshRenderers = new List<MeshRenderer>();

    public Animator animator;

   public  Projector projector;
    // Start is called before the first frame update
    void Start()
    {
        EventCenter.AddListener(EventDefine.GoDefaultScene, ShowMesh);
        EventCenter.AddListener(EventDefine.GoSoloScene, HideMesh);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMesh()
    {
        foreach (var item in meshRenderers)
        {
            item.enabled = true;
        }
        projector.enabled = true;
    }

    public void HideMesh() {
        foreach (var item in meshRenderers)
        {
            item.enabled = false;
        }
        projector.enabled = false;
    }

    public void PlayLoop() {
        animator.SetBool("TurnONLoop", true);
    }
}
