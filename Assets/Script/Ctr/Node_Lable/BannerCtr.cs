using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum NodeType {
LeftNode,RightNode
}

public class BannerCtr : MonoBehaviour
{
    public List<Node_LableCtr> node_LableCtrs = new List<Node_LableCtr>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartNodeLableAnimation());
    }

    IEnumerator StartNodeLableAnimation() {
        foreach (var item in node_LableCtrs)
        {
            float val = Random.Range(2f, 3f);

            yield return new WaitForSeconds(val);
            if (item.nodeType == NodeType.RightNode)
            {
                item.animator.SetInteger("Play", 0);

            }
            else if (item.nodeType == NodeType.LeftNode) {
                item.animator.SetInteger("Play", 1);
            }

        }
    }


    public void ini() {
        foreach (var ctr in node_LableCtrs)
        {
            ctr.ini(ValueSheet.BannerNodeSprites[node_LableCtrs.IndexOf(ctr)]);
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
