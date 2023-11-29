using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float vitesseDefilement;
    Renderer textureQuad;

    // Start is called before the first frame update
    void Start()
    {
        textureQuad = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * vitesseDefilement;
        textureQuad.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
