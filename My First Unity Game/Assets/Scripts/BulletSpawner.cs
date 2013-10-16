using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour 
{

    public GameObject mainCam;
    public CameraControl mainCamController;
    public Transform slug;

	// Use this for initialization
	void Start () 
    {
        if (mainCam == null)
            mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        mainCamController = mainCam.GetComponent<CameraControl>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (mainCamController.firing)
        {
            transform.LookAt(mainCamController.target.point);
            if (mainCamController.aimed)
                Instantiate(slug, transform.position, transform.rotation);
            else
                Instantiate(slug, transform.position, mainCam.transform.rotation);
            audio.Play();
            mainCamController.firing = false;
        }
	}
}
