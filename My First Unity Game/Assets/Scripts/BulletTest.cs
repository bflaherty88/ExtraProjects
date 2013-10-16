using UnityEngine;
using System.Collections;

public class BulletTest : MonoBehaviour {

    public Transform slug;
    private bool fired = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if ((int)Time.time % 2 == 1)
        {
            if (!fired)
            {
                Instantiate(slug, transform.position, transform.rotation);
                fired = true;
            }
        }
        else
            fired = false;
	}
}
