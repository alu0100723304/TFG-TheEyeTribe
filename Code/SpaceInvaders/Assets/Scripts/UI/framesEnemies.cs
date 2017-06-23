using UnityEngine;
using System.Collections;

public class framesEnemies : MonoBehaviour {

    public GameObject framea;
    public GameObject frameb;

    private bool frame = true;
    private 

    // Use this for initialization
    void Start () {
        show(framea);
        hide(frameb);

        InvokeRepeating("UpdateFrame", 0, 0.75f);
    }
	
	// Update is called once per frame
	void UpdateFrame () {
	    if (frame)
        {
            show(framea);
            hide(frameb);
            frame = false;
        }
        else
        {
            show(frameb);
            hide(framea);
            frame = true;
        }
	}

    private void hide (GameObject gameObject)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void show (GameObject gameObject)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}
