using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Oculus.Avatar;

public class AvatarOvr : NetworkBehaviour {

    public override void OnStartLocalPlayer()
    {
        GameObject camera = Camera.main.gameObject;
        transform.parent = camera.transform;
        transform.localPosition = Vector3.zero;

        GetComponent<OvrAvatar>().enabled = false;
    }
}
