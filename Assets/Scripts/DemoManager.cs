using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoManager : MonoBehaviour
{


    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;

    [SerializeField] private Animator characterController;

    [SerializeField] private GameObject cape;
    [SerializeField] private GameObject cape_Point;
    [SerializeField] private GameObject playerHead;

    [SerializeField] private Button playBtn;
    [SerializeField] private List<Button> listOfAnimationBtn;

    [SerializeField] private Button play_animation;

    private Rigidbody cape_rb;

    private bool drop;

    private float incValue;
    private float dist;

    public readonly int MyAnimate = Animator.StringToHash("animate");


    private void Awake()
    {
        cape_rb = cape_Point.GetComponent<Rigidbody>();
        play_animation.interactable = false;
    }

    private void Update()
    {
        if (drop)
        {
            dist = Vector3.Distance(playerHead.transform.position, cape_Point.transform.position);

            if (dist <= 0.6f)
            {
                cape_rb.useGravity = false;
                drop = false;

            }
        }
    }
    private void OnEnable()
    {
        DemoEventHolder.OnPlayAnimation += PlayAnimation;
        DemoEventHolder.OnPlayPressed += DropCape;
        DemoEventHolder.OnIncreaseWaist += IncreaseWaist;
        DemoEventHolder.OnDecreaseWaist += DecreaseWaist;
    }

    private void OnDisable()
    {
        DemoEventHolder.OnPlayAnimation -= PlayAnimation;
        DemoEventHolder.OnPlayPressed -= DropCape;
        DemoEventHolder.OnIncreaseWaist -= IncreaseWaist;
        DemoEventHolder.OnDecreaseWaist -= DecreaseWaist;

    }




    private void DropCape()
    {
        StartCoroutine(DropCloth());

    }

    private void PlayAnimation()
    {
        if (!characterController.enabled)
        {
            characterController.enabled = !characterController.enabled;

        }

        cape.SetActive(false);
        characterController.SetTrigger(MyAnimate);
        playBtn.interactable = false;
    }


    private void IncreaseWaist()
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

        skinnedMeshRenderer.SetBlendShapeWeight(0, incValue * 100);
    }


    private void DecreaseWaist()
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

        skinnedMeshRenderer.SetBlendShapeWeight(0, incValue * 100);
    }

    IEnumerator DropCloth()
    {
        drop = true;
        cape_Point.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(0.5f);
        play_animation.interactable = true;

    }
}
