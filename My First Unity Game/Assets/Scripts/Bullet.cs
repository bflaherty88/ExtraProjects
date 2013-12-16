using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public int bulletSpeed = 20;
    public int dam = 5;

    protected float rayLength;
    protected RaycastHit hit;
    protected bool struck = false;

	// Use this for initialization
	void Start () 
    {
        rayLength = bulletSpeed / 20;
	}
	
	void Update () 
    {
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayLength))
        {
            if (!hit.collider.isTrigger)
            {
                Destroy(this.gameObject);
                struck = true;
            }
        }
	}

    void OnDestroy()
    {
        if (struck)
        {
            if (hit.collider.gameObject.tag.Equals("Player"))
            {
                hit.collider.gameObject.GetComponent<CharacterControl>().health -= dam;
            }
            if (hit.collider.gameObject.tag.Equals("Target"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
