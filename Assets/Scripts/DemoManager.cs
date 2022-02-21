using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoManager : MonoBehaviour
{

    [SerializeField] private DataHolder dataHolder;

    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private SkinnedMeshRenderer clothSkinnedMeshRenderer;

    [SerializeField] private Animator characterController;

    [SerializeField] private GameObject cape;
    [SerializeField] private GameObject cape_Point;
    [SerializeField] private GameObject playerHead;

    [SerializeField] private Transform characterMain;

    [SerializeField] private Button playBtn;

    [SerializeField] private Button play_animation;

    private Rigidbody cape_rb;

    private bool drop;

    private float incValue;
    private float dist;

    public readonly int MyAnimate = Animator.StringToHash("animate");
    public readonly int MyPose1 = Animator.StringToHash("dynamic");
    public readonly int MyPose2 = Animator.StringToHash("sleep");
    public readonly int MyPoseIdle = Animator.StringToHash("idle");

    private void Awake()
    {
        cape_rb = cape_Point.GetComponent<Rigidbody>();
        play_animation.interactable = false;
       
    }

    private void Update()
    {
        //if (characterController.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !characterController.IsInTransition(0))
        //{
     
        //   characterMain.localPosition = new Vector3(0, 0, 0);
        //}

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
        DemoEventHolder.OnChangePose1 += ChangePose1;
        DemoEventHolder.OnChangePose2 += ChangePose2;
        DemoEventHolder.OnChangeIdle +=  ChangeIdle;

        DemoEventHolder.OnChangeColor1 += ChangeColor1;
        DemoEventHolder.OnChangeColor2 += ChangeColor2;

        DemoEventHolder.OnPlayAnimation += PlayAnimation;
        DemoEventHolder.OnPlayPressed += DropCape;
        DemoEventHolder.OnIncreaseWaist += IncreaseWaist;
        DemoEventHolder.OnDecreaseWaist += DecreaseWaist;
    }

    private void OnDisable()
    {
        DemoEventHolder.OnChangePose1 -= ChangePose1;
        DemoEventHolder.OnChangePose2 -= ChangePose2;
        DemoEventHolder.OnChangeIdle -=  ChangeIdle;

        DemoEventHolder.OnChangeColor1 -= ChangeColor1;
        DemoEventHolder.OnChangeColor2 -= ChangeColor2;

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

        //cape.SetActive(false);
        characterController.SetTrigger(MyAnimate);
        playBtn.interactable = false;
    }

    private void ChangePose1()
    {
        if (!characterController.enabled)
        {
            characterController.enabled = !characterController.enabled;

        }
        characterController.SetTrigger(MyPose1);
        playBtn.interactable = false;
    }

    private void ChangePose2()
    {
        if (!characterController.enabled)
        {
            characterController.enabled = !characterController.enabled;

        }
        characterController.SetTrigger(MyPose2);
        playBtn.interactable = false;
    }

    private void ChangeIdle()
    {
        if (!characterController.enabled)
        {
            characterController.enabled = !characterController.enabled;

        }
        characterController.SetTrigger(MyPoseIdle);
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

    private void ChangeColor1()
    {
        clothSkinnedMeshRenderer.material = dataHolder.clothMaterialSet[0];
    }

    private void ChangeColor2()
    {
        clothSkinnedMeshRenderer.material = dataHolder.clothMaterialSet[1];
    }
    IEnumerator DropCloth()
    {
        drop = true;
        cape_Point.GetComponent<Rigidbody>().useGravity = true;
        yield return new WaitForSeconds(0.5f);
        play_animation.interactable = true;

    }
}
