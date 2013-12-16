using UnityEngine;
using System.Collections;

public class WorldControl : MonoBehaviour {

    public Texture crosshairs;
    public GUIStyle menuStyle, statStyle;
    public GameObject player;
    public int targetCount;
    public GameObject endDoor;

    private CharacterControl playerControl;
    private Rect center = new Rect(Screen.width / 2f, Screen.height / 2f, 0f, 0f);
    
    protected bool paused, dead, finishing, finished;
    protected string stats;

    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        if (endDoor == null)
            endDoor = GameObject.FindGameObjectWithTag("EndDoor");
        playerControl = player.GetComponent<CharacterControl>();
        paused = false;
        dead = false;
        finishing = false;
        finished = false;
        Time.timeScale = 1f;
    }

	void Update () 
    {
        if (!finished)
        {
            if (Input.GetButtonDown("Pause"))
                pause();

            if (playerControl.health <= 0)
                die();
        }

        stats = string.Format("Health: {0}\nRemaining Targets: {1}", playerControl.health, targetCount);

        if (targetCount == 0)
            StartCoroutine(openEnd());

        if (LevelEnd.isFinished)
            finishLevel();
	}
	
	// Update is called once per frame
	void OnGUI () 
    {
        if (!paused)
        {
            if (finishing)
            {
                GUI.Label(center, "Complete", menuStyle);
            }
            else if (finished)
            {
                if (GUI.Button(new Rect(Screen.width / 3f, Screen.height / 2f - 36f, Screen.width / 3f, 72), "Restart?", menuStyle))
                    Application.LoadLevel(0);
            }
            else
                GUI.DrawTexture(new Rect(Screen.width / 2 - 16f, Screen.height / 2 - 16f, 32f, 32f), crosshairs);
        }
        else
        {
            GUI.Label(center, "Paused", menuStyle);
        }

        GUI.Label(new Rect(0f, Screen.height, 0f, 0f), stats, statStyle);

        
        if (dead)
            GUI.Label(center, "Dead", menuStyle);
	}

    void pause()
    {
        paused = !paused;
        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void die()
    {
        dead = true;
        Time.timeScale = 0;
    }
    IEnumerator openEnd()
    {
        yield return new WaitForSeconds(1f);
        Destroy(endDoor);
    }

    protected void finishLevel()
    {
        if (!finished)
        {
            paused = false;
            StartCoroutine(Finish());
        }
    }

    IEnumerator Finish()
    {
        finishing = true;
        yield return new WaitForSeconds(2f);
        finishing = false;
        finished = true;
        Time.timeScale = 0f;
    }
}
