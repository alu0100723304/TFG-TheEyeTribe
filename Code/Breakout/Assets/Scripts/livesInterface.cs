using UnityEngine;
using UnityEngine.UI;


public class livesInterface : MonoBehaviour {

    public Text lives;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        lives.text = " " + Global.lives;
    }
}
