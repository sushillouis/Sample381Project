using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ETextFX
{
    Rotate = 0,
    Pulse,
    Roll,
    Spin
}
public class TextFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        startFontSize = GetComponentInParent<Text>().fontSize;
    }
    public ETextFX effect;

    float fontSize;
    float startFontSize;
    public float minFontSize = 30;
    public float fontScaleRate = 10;

    public float rate = 60;

    // Update is called once per frame
    void Update()
    {
        switch (effect) {
            case ETextFX.Rotate:
                transform.Rotate(Vector3.up, rate * Time.deltaTime);
                break;
            case ETextFX.Roll:
                transform.Rotate(Vector3.left, rate * Time.deltaTime);
                break;
            case ETextFX.Pulse:
                DeltaScale();
                GetComponentInParent<Text>().fontSize = Mathf.FloorToInt(fontSize);
                break;
            case ETextFX.Spin:
                transform.Rotate(Vector3.forward, rate * Time.deltaTime);
                break;

            default:
                break;
        }

    }

    void DeltaScale()
    {
        if (fontSize < minFontSize)
            fontSize = startFontSize;
        else
            fontSize -= fontScaleRate * Time.deltaTime;


    }
}
