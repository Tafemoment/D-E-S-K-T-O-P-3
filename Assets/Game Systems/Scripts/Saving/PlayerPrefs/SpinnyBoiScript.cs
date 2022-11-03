using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Make cube spin. Save its rotation via a key that also closes playmode. Loads save for return to playmode.
public class SpinnyBoiScript : MonoBehaviour
{
    public bool spin;
    public Vector3 spinAmount;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            spin = !spin;
        }
        if (spin)
        {
            this.gameObject.transform.Rotate(spinAmount);
        }
    }


}
