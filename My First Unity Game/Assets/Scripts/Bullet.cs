using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public int bulletSpeed = 20;

    protected float rayLength;
    protected RaycastHit hit;

	// Use this for initialization
	void Start () 
    {
        rayLength = bulletSpeed / 20;
	}
	
	void Update () 
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayLength))
            Destroy(this.gameObject);
	}

    void OnDestroy()
    {
        if (!hit.Equals(null))
        {
            if (hit.collider.gameObject.tag.Equals("Player"))
            {
                hit.collider.gameObject.GetComponent<CharacterControl>().health -= 5;
                Debug.Log("Ouch");
            }
            if (hit.collider.gameObject.tag.Equals("Target"))
            {
                Destroy(hit.collider.gameObject);
                Debug.Log("Poof");
            }
        }
    }
}
