using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BotonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if ( gameObject.name == "Toggle" )
        {
            //GetComponentsInChildren<Text> ()[1].color = Color.white;
        }
        else
        {
            GetComponent<Text> ().color = Color.white;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FeedBack()
    {
        if (gameObject.name == "exit" || gameObject.name == "delete")
        {
            GetComponent<Text>().color = Color.red;
        }
        else if (gameObject.name == "Toggle")
        {
           // GetComponentsInChildren<Text> ()[1].color = Color.green;
        }
        else
        {
            GetComponent<Text>().color = Color.green;
        }
    }

    public void DisableFeedBack()
    {
        if ( gameObject.name == "Toggle" )
        {
            //GetComponentsInChildren<Text> () [1].color = Color.white;
        }
        else
        {
            GetComponent<Text> ().color = Color.white;
        }
    }
}
