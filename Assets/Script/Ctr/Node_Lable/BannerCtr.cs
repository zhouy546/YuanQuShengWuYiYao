using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            float val = Random.Range(3f, 6f);

            yield return new WaitForSeconds(val);
            item.animator.SetBool("Play", true);
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
