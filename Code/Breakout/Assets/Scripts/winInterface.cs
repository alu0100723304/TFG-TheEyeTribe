using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class winInterface : MonoBehaviour {

    public Text fin;
	public Text finalPoints;

	// Update is called once per frame
	void Start () {
        if (Global.win) {
            fin.text = "You win";
        }
        else {
            fin.text = "Game Over";
        }
		finalPoints.text = finalPoints.text + "" + Global.points;
    }

    /*void OnGUI() {
        textFieldString = GUI.TextField(new Rect(500, 25, 100, 30), textFieldString, 25);
        //GUI.Label(new Rect(505, 75, 100, 100), textFieldString);
    }*/
}
