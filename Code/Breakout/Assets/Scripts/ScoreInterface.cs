using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreInterface : MonoBehaviour {

    public Text score;

	
	// Update is called once per frame
	void Update () {
        score.text = "Score: " + Global.points;
	
	}
}
