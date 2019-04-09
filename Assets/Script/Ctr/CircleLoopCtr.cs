using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleLoopCtr : MonoBehaviour
{
    public List<CircleNodeCtr> CircleNode_animators = new List<CircleNodeCtr>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartAnimator());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartAnimator() {
        yield return new WaitForSeconds(2f);
        foreach (var item in CircleNode_animators)
        {
            item.PlayLoop();
            yield return new WaitForSeconds(0.3f);
        }
    }
}
