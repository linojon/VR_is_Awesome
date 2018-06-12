using UnityEngine;

public class Clicker : MonoBehaviour {

    private void Update()
    {
        Clicked();
    }

    public bool Clicked()
    {
        if (Input.anyKey)
            Debug.Log("anyKey");
        if (Input.GetButton("Fire1"))
            Debug.Log("Fire1");
        return Input.anyKeyDown;
    }
}
