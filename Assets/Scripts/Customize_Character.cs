using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customize_Character : MonoBehaviour
{

    SkinnedMeshRenderer SkinnedMeshRenderer;

    private float incValue { get; set; }
    private float previousValue;
    
    public Slider slider;
    public GameObject Character;


    bool inc, dec;

    void Awake()
    {

        SkinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();

        this.slider.onValueChanged.AddListener(this.OnSliderChanged);

    }

    private void Update()
    {
        if (inc)
        {
            incValue = incValue*Time.deltaTime;
            SkinnedMeshRenderer.SetBlendShapeWeight(0, incValue*Time.deltaTime * 100);
        }

        if (dec)
        {
      
            SkinnedMeshRenderer.SetBlendShapeWeight(0, incValue*Time.deltaTime * 100);

        }
    }

    void OnSliderChanged(float value)
    {
        this.Character.transform.rotation = Quaternion.Euler(0, slider.value*360, 0);
    }

    public void OnButtonIncrease()
    {

        print("it is printing " +incValue);
        if (incValue * 100 <= 100)
        {
            incValue += 0.1f;
        }
        SkinnedMeshRenderer.SetBlendShapeWeight(0, incValue * 100);
    }

    public void OnButtonDecrease()
    {
        print("it is printing dec " +incValue);

        if (incValue * 100 >= 0)
        {
            incValue -= 0.1f;
        }
        SkinnedMeshRenderer.SetBlendShapeWeight(0, incValue * 100);
        
    }
}
