using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

    protected bool recoiling, pushed;
    protected float startDistance;

    public RaycastHit target, hit;
    public bool firing;
    public float recoilTime = 0.5f;
    public bool aimed;
    public float upperBar = 90;
    public float pushSpeed = 10;

    // Use this for initialization
    void Start()
    {
        startDistance = Vector3.Distance(transform.position, transform.parent.position);
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            if ((transform.localEulerAngles.x < 60 || transform.localEulerAngles.x >= 270) && Input.GetAxis("Mouse Y") < 0f)
                transform.RotateAround(transform.parent.position, -transform.parent.right, Input.GetAxis("Mouse Y"));
            else if ((transform.localEulerAngles.x > 300 || transform.localEulerAngles.x <= 70) && Input.GetAxis("Mouse Y") > 0f)
                transform.RotateAround(transform.parent.position, -transform.parent.right, Input.GetAxis("Mouse Y"));

        }
        
        if (Input.GetButtonDown("Fire1") && Time.timeScale != 0)
            StartCoroutine(fire());

        if (Physics.Raycast(transform.position, -transform.forward, 0.5f))
        {
            transform.Translate(Vector3.forward * pushSpeed);
        }
        else if (!Physics.Raycast(transform.position, -transform.forward, 0.6f) && Vector3.Distance(transform.position, transform.parent.position) < startDistance)
            transform.Translate(Vector3.forward * -pushSpeed);

        if (Physics.Raycast(transform.position, transform.InverseTransformPoint(transform.parent.position)))
        {
            transform.Translate(Vector3.forward * pushSpeed);
            Debug.Log("loggy loggy log.");
        }
            Debug.DrawRay(transform.parent.position, transform.forward * 100);

        //Debug.DrawRay(transform.position, transform.TransformPoint(transform.parent.position));
        /*
        if (pushed)
        {
            transform.Translate(Vector3.forward * pushSpeed);
            pushed = false;
        }
        else if (Vector3.Distance(transform.position, transform.parent.position) < startDistance)
            transform.Translate(Vector3.forward * -pushSpeed);
         */
    }

    IEnumerator fire()
    {
        if (recoiling)
            yield return null;
        else
        {
            aimed = Physics.Raycast(transform.parent.position, transform.forward, out target);
            firing = true;
            recoiling = true;
            yield return new WaitForSeconds(recoilTime);
            recoiling = false;
        }
    }
    /*
    void OnTriggerStay()
    {
        pushed = true;
    }
     */
}
