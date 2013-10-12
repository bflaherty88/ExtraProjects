using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    protected bool recoiling;

    public RaycastHit target;
    public bool firing;
    public float recoilTime = 0.5f;
    public bool aimed;

	// Use this for initialization
	void Start () {
	
	}
	
	void Update () 
    {
        if (transform.localRotation.x < 0.5 && Input.GetAxis("Mouse Y") < 0f)
            transform.RotateAround(transform.parent.position, -transform.parent.right, Input.GetAxis("Mouse Y"));
        else if (transform.localRotation.x > -0.2 && Input.GetAxis("Mouse Y") > 0f)
            transform.RotateAround(transform.parent.position, -transform.parent.right, Input.GetAxis("Mouse Y"));

        if (Input.GetButtonDown("Fire1"))
            StartCoroutine(fire());

        Debug.DrawRay(transform.position, transform.forward * 100);
	}

    IEnumerator fire()
    {
        if (recoiling)
            yield return null;
        else
        {
            aimed = Physics.Raycast(transform.position, transform.forward, out target);
            Debug.Log(aimed.ToString());
            firing = true;
            recoiling = true;
            yield return new WaitForSeconds(recoilTime);
            recoiling = false;
        }
    }

}
