using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupCtr : MonoBehaviour
{

    public List<CanvasNodeCtr> canvasNodeCtrs = new List<CanvasNodeCtr>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ini() {
        foreach (var item in canvasNodeCtrs)
        {
            item.ini(canvasNodeCtrs.IndexOf(item));
        }
    }
}
