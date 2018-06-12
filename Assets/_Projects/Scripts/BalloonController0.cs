using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BalloonController0 : MonoBehaviour {
    //public GameObject meMyselfEye;

    public GameObject balloonPrefab;
    public float floatStrength = 20f;
    public float growRate = 1.5f;

    //private MyInputController inputController;
    //public MyInputState inputState;

    //UnityEvent ButtonDownEvent;
    //UnityEvent ButtonUpEvent;

    private GameObject balloon;

	void Start () {
        //inputController = meMyselfEye.GetComponent<MyInputController>();

        //ButtonDownEvent.AddListener(NewBalloon);
       // ButtonUpEvent.AddListener(ReleaseBalloon);
	}

    void Update()
    {
        if (balloon != null)
            GrowBalloon();
    }

    // Update is called once per frame
    //void Update () {
    //       //if (inputController.ButtonDown())
    //       if (inputState.buttonAction == MyInputState.ButtonAction.PressedDown)
    //       {
    //           NewBalloon();
    //       }
    //       //else if (inputController.ButtonUp())
    //       else if (inputState.buttonAction == MyInputState.ButtonAction.ReleasedUp)
    //       {
    //           ReleaseBalloon();
    //       }
    //       else if (balloon != null)
    //       {
    //           GrowBalloon();
    //       }
    //}

    public void NewBalloon(GameObject parentHand)
    {
        if (balloon == null)
        {
            //balloon = Instantiate(balloonPrefab, Vector3.zero, Quaternion.identity, parentHand.transform);
            balloon = Instantiate(balloonPrefab);
            balloon.transform.SetParent(parentHand.transform);
            balloon.transform.localPosition = Vector3.zero;

        }
    }

    public void ReleaseBalloon()
    {
        if (balloon != null)
        {
            balloon.transform.parent = null;
            balloon.GetComponent<Rigidbody>().AddForce(Vector3.up * floatStrength);
        }
        balloon = null;
    }

    void GrowBalloon()
    {
        balloon.transform.localScale += balloon.transform.localScale * growRate * Time.deltaTime;
    }

}