using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateBorder : MonoBehaviour
{
    private Image image;
    private float H;
    private float S;
    private float V;
    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Color.RGBToHSV(image.color, out H, out S, out V);
        H += 0.0002f;
        if (H >= 1) H = 0;
        S = 0.5f;
        V = 1f;
        image.color = Color.HSVToRGB(H, S, V);
    }
}
