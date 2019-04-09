using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCircleColor : MonoBehaviour
{
    public Color MainColor;

    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = this.GetComponent<MeshRenderer>();

        meshRenderer.material.SetColor("_MainColor", MainColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
