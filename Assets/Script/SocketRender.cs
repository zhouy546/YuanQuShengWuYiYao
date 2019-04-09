using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketRender : MonoBehaviour
{
    public List<MeshRenderer> socketMeshRenders = new List<MeshRenderer>();

    public static SocketRender instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        }
        EventCenter.AddListener(EventDefine.GoDefaultScene, disableAll);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableOneDisableOther(int id) {
        for (int i = 0; i < socketMeshRenders.Count; i++)
        {
            if (id == i)
            {
                socketMeshRenders[i].enabled = true;
            }
            else {
                if (socketMeshRenders[i].enabled) {
                    socketMeshRenders[i].enabled = false;
                }
            }
        }
    }

    public void disableAll() {
        foreach (var item in socketMeshRenders)
        {
            item.enabled = false;
        }
    }

}
