using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DisableFeedBack();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void FeedBack ()
    {
        GetComponent<Image>().color = Color.white;
        GetComponentInChildren<Text>().color = Color.black;
    }

    public void DisableFeedBack ()
    {
        GetComponent<Image>().color = Color.black;
        GetComponentInChildren<Text>().color = Color.white;
    }
}
