using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueSheet : MonoBehaviour
{
    public static List<Sprite> BannerNodeSprites= new List<Sprite>();

    public static List<CanvasNode> canvasNodes = new List<CanvasNode>();

    public static Dictionary<string, CanvasNodeCtr> UDP_CanvasNodeCtrPair = new Dictionary<string, CanvasNodeCtr>();

    public static List<List<Sprite>> canvasGroupSprites = new List<List<Sprite>>();
}

public class CanvasGroupSprite {
    public List<Sprite> sprites = new List<Sprite>();

    public CanvasGroupSprite() {

    }

    public CanvasGroupSprite(List<Sprite> _sprites)
    {
        sprites = _sprites;
    }
}
