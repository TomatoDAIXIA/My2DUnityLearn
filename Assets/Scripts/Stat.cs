using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    private Image imageContent;
    

    private float currentFill;

    private float currentValue;

    public float MyMaxValue { get; set; }

    [SerializeField]
    private Text statValue;

    public float MyCurrentValue
    {
        get { return currentValue; }
        set
        {
            currentValue = Mathf.Clamp(value, 0, MyMaxValue);
            currentFill = currentValue / MyMaxValue;
            statValue.text = $"{currentValue}/{MyMaxValue}";
        }
    }

    private float lerpSpeed = 10;

    void Start()
    {
        imageContent = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        imageContent.fillAmount = Mathf.Lerp(imageContent.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
    }

    public void Initialized(float currentValue, float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;

     

    }
}
