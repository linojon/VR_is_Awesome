using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popable : MonoBehaviour {
    public GameObject popEffect;


    void OnCollisionEnter(Collision collision)
    {
        PopBalloon();
    }

    private void PopBalloon()
    {
        Instantiate(popEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
