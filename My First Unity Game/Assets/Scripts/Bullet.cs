using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public int bulletSpeed = 20;
    protected float rayLength = 0.5f;

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)/12.5f);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), rayLength))
            Destroy(this.gameObject);
	}
}
