using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_BgScroll : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    Material mat;
    private float xScroll;

    private void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        xScroll = Time.time * scrollSpeed;
        Vector2 _offset = new Vector2(xScroll, transform.position.y);
        mat.mainTextureOffset = _offset;
    }
}