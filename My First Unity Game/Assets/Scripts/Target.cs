using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

    public GameObject worldController;

    protected WorldControl worldControl;

	void Start () 
    {
        if (worldController == null)
            worldController = GameObject.FindGameObjectWithTag("GameController");
        worldControl = worldController.GetComponent<WorldControl>();
        worldControl.targetCount++;
	}
	
	void OnDestroy ()
    {
        worldControl.targetCount--;
    }
}
