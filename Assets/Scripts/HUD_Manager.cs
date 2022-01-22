using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Manager : MonoBehaviour
{


    public Slider slider;

    public Button playBtn;
    public Button increaseWaist, decreaseWaist;
    public Button play_animation;

    public GameObject cowBoyHat;
    public GameObject Character;

    public SkinnedMeshRenderer SkinnedMeshRenderer;

    public Animator characterController;

    private float incValue;



    // Start is called before the first frame update
    void Awake()
    {
        this.playBtn.onClick.AddListener(this.OnPlay);

        this.increaseWaist.onClick.AddListener(this.OnButtonIncrease);
        this.decreaseWaist.onClick.AddListener(this.OnButtonDecrease);
        this.play_animation.onClick.AddListener(this.PlayAnimation);

        this.slider.onValueChanged.AddListener(this.OnSliderChanged);
    }

    void OnPlay()
    {
        // To Drop the Hat
        StartCoroutine(DropHat());
    }



     private void OnSliderChanged(float value)
    {
        //To Rotate the Character with slider
        Character.transform.rotation = Quaternion.Euler(0, slider.value * 360, 0);
    }

    private void OnButtonIncrease()
    {
        //Disabling Controller because it overrides blendshapes of model
        if (characterController.enabled)
        {
            characterController.enabled = !characterController.enabled;
        }

        // To keep value within 0 - 100
        if (incValue * 100 <= 100)
        {
            incValue += 0.1f;
        }

        SkinnedMeshRenderer.SetBlendShapeWeight(0, incValue * 100);
    }

    private void OnButtonDecrease()
    {
        
        //Disabling Controller because it overrides blendshapes of model
        if (characterController.enabled)
        {
            characterController.enabled = !characterController.enabled;
        }

        // To keep value within 0 - 100
        if (incValue * 100 >= 0)
        {
            incValue -= 0.1f;
        }

        SkinnedMeshRenderer.SetBlendShapeWeight(0, incValue * 100);

    }


    private void PlayAnimation()
    {
        if (!characterController.enabled)
        {
            characterController.enabled = !characterController.enabled;

        }
        characterController.SetTrigger("animate");

    }

    IEnumerator DropHat()
    {
        cowBoyHat.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        cowBoyHat.GetComponent<Rigidbody>().useGravity = false;
        play_animation.interactable = true;

    }
}
