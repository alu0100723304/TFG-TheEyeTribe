using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class updatePoints : MonoBehaviour {

    private static Text score;
    private static int points_ = 0;

	// Use this for initialization
	void Start () {
        points_ = 0;
        score = GameObject.Find("Points").GetComponent<Text>();
	}
	
	public static void add (int points)
    {
        points_ += points;
        score.text = points_.ToString();
    }

    public static int getPoints ()
    {
        return points_;
    }
}
