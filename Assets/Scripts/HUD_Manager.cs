using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD_Manager : MonoBehaviour
{


    [SerializeField] private Slider slider;

    [SerializeField] private Button playBtn;
    [SerializeField] private Button increaseWaist, decreaseWaist;
    [SerializeField] private Button play_animation;
    [SerializeField] private Button pose_one;
    [SerializeField] private Button pose_two;
    [SerializeField] private Button pose_idle;

    [SerializeField] private Button changeColor1;
    [SerializeField] private Button changeColor2;

    [SerializeField] private GameObject character;


    private float dist;
    private bool drop;

    // Start is called before the first frame update
    void Awake()
    {
        playBtn.onClick.AddListener(this.OnPlay);

        increaseWaist.onClick.AddListener(OnButtonIncrease);
        decreaseWaist.onClick.AddListener(OnButtonDecrease);
        play_animation.onClick.AddListener(PlayAnimation);

        pose_one.onClick.AddListener(Pose1);
        pose_two.onClick.AddListener(Pose2);
        pose_idle.onClick.AddListener(Idle);

        changeColor1.onClick.AddListener(ChangeColor1);
        changeColor2.onClick.AddListener(ChangeColor2);

        slider.onValueChanged.AddListener(OnSliderChanged);

    }
    void OnPlay()
    {
        // To Drop the Cape
        DemoEventHolder.OnPlayPressed?.Invoke();
    }


    private void ChangeColor1()
    {
        //To change the material of cloth
        DemoEventHolder.OnChangeColor1?.Invoke();
    }

    private void ChangeColor2()
    {
        //To change the material of cloth
        DemoEventHolder.OnChangeColor2?.Invoke();
    }
    private void OnSliderChanged(float value)
    {
        //To Rotate the Character with slider
        character.transform.rotation = Quaternion.Euler(0, slider.value * 360, 0);
    }

    private void OnButtonIncrease()
    {
        DemoEventHolder.OnIncreaseWaist?.Invoke();
    }

    private void OnButtonDecrease()
    {

        DemoEventHolder.OnDecreaseWaist?.Invoke();

    }


    private void PlayAnimation()
    {

        DemoEventHolder.OnPlayAnimation?.Invoke();

    }

    private void Pose1()
    {
        DemoEventHolder.OnChangePose1?.Invoke();
    }

    private void Pose2()
    {
        DemoEventHolder.OnChangePose2?.Invoke();
    }

    private void Idle()
    {
        DemoEventHolder.OnChangeIdle?.Invoke();

    }

    public void LogoutScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
