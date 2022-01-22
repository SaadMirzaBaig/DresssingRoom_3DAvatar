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

    public GameObject Character;

    public SkinnedMeshRenderer SkinnedMeshRenderer;

    public Animator characterController;

    private float incValue;

    public GameObject Cape_Point;
    public GameObject PlayerHead;
    public GameObject Cape;
    private float dist;

    private bool drop;

    // Start is called before the first frame update
    void Awake()
    {
        this.playBtn.onClick.AddListener(this.OnPlay);

        this.increaseWaist.onClick.AddListener(this.OnButtonIncrease);
        this.decreaseWaist.onClick.AddListener(this.OnButtonDecrease);
        this.play_animation.onClick.AddListener(this.PlayAnimation);

        this.slider.onValueChanged.AddListener(this.OnSliderChanged);
    }

    private void Update()
    {

        if (drop)
        {
            dist = Vector3.Distance(PlayerHead.transform.position, Cape_Point.transform.position);

            if (dist <= 0.6f)
            {
                Cape_Point.GetComponent<Rigidbody>().useGravity = false;
                drop = false;

            }
        }

    }
    void OnPlay()
    {
        // To Drop the Hat
        StartCoroutine(DropCloth());
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

    IEnumerator DropCloth()
    {
        drop = true;
        Cape.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        play_animation.interactable = true;

    }
}
