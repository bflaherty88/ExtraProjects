using UnityEngine;
using System.Collections;

public class GunControl : MonoBehaviour {

    public GameObject mainCam;

	void Start () 
    {
        if (mainCam == null)
            mainCam = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Time.timeScale != 0)
        {
            if ((transform.localEulerAngles.x < 60 || transform.localEulerAngles.x >= 270) && Input.GetAxis("Mouse Y") < 0f)
                transform.RotateAround(transform.parent.position, -transform.parent.right, Input.GetAxis("Mouse Y"));
            else if ((transform.localEulerAngles.x > 300 || transform.localEulerAngles.x <= 70) && Input.GetAxis("Mouse Y") > 0f)
                transform.RotateAround(transform.parent.position, -transform.parent.right, Input.GetAxis("Mouse Y"));
        }
	}
}
