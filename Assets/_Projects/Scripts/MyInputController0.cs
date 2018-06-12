using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MyInputController0 : MonoBehaviour {

    //public GameObject handController;
#if UNITY_STANDALONE
    private SteamVR_TrackedObject trackedObjectHand;
    private SteamVR_Controller.Device device;
#endif

    void Start()
    {
#if UNITY_STANDALONE
        //trackedObjectHand = handController.GetComponent<SteamVR_TrackedObject>();
#endif
    }

    //public MyInputState myInputstate;


    // Update is called once per frame
    //void Update () {
    //       //ButtonTest();
    //       if (ButtonDown())
    //       {
    //           myInputstate.buttonAction = MyInputState.ButtonAction.PressedDown;
    //       } else if (ButtonUp())
    //       {
    //           myInputstate.buttonAction = MyInputState.ButtonAction.ReleasedUp;
    //       } else
    //       {
    //           myInputstate.buttonAction = MyInputState.ButtonAction.None;
    //       }
    //}

    public UnityEvent ButtonDownEvent;
    public UnityEvent ButtonUpEvent;

    void Update()
    {
        if (ButtonDown())
            ButtonDownEvent.Invoke();
        else if (ButtonUp())
            ButtonUpEvent.Invoke();
    }


    public bool ButtonDown()
    {
#if UNITY_ANDROID
        return GvrControllerInput.ClickButtonDown;
#else
        return Input.GetButtonDown("Fire1");
#endif
    }

    public bool ButtonUp()
    {
#if UNITY_ANDROID
        return GvrControllerInput.ClickButtonUp;
#else
        return Input.GetButtonUp("Fire1");
#endif
    }


    private void ButtonTest()
    {
        string msg = null;

        if (Input.GetButtonDown("Fire1"))
            msg = "Fire1 down";
        if (Input.GetButtonUp("Fire1"))
            msg = "Fire1 up";

#if UNITY_STANDALONE
        // SteamVR
        //device = SteamVR_Controller.Input((int)trackedObjectHand.index);
        //if (device != null && device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        //{
        //    msg = "Trigger press";
        //    device.TriggerHapticPulse(700);
        //}
        //if (device != null && device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
        //    msg = "Trigger release";
#endif
#if UNITY_ANDROID
        if (GvrControllerInput.ClickButtonDown)
            msg = "Button down";
        if (GvrControllerInput.ClickButtonUp)
            msg = "Button up";
#endif

        if (msg != null)
            Debug.Log("Input: " + msg);


    }
}
