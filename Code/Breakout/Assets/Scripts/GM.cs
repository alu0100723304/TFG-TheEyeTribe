using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class GM : MonoBehaviour {
	//variables
	//public float resetDelay = 0.1f; //Time before de game resets when we finish
	public int bricks; //new bricks
	public GameObject bar;
	public static GM instance = null;
    public int nextLevel;
	private GameObject newBar;
	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		Setup ();
	}

	public void Setup(){
		newBar = Instantiate (bar, transform.position, Quaternion.identity) as GameObject;
	}

	void FinishGame(){
		if (bricks < 1) {
            //Are we in the last level?
            if (nextLevel == 0) {
                Global.win = true;
                SceneManager.LoadScene("FinishGame");
            }
            else {
				string aux = String.Concat("Level", nextLevel);
				SceneManager.LoadScene(aux);
            }
        }

        if(Global.lives == 0) {
            SceneManager.LoadScene("FinishGame");
        }
    }

	/*void LoadLevel(){
		//Time.timeScale = 1f;
        string aux = String.Concat("Level", nextLevel);
        SceneManager.LoadScene(aux);
    }*/

    public void DestroyBrick(){
		bricks--;
        Global.points ++;
		FinishGame();
	}

	public void Lose(){
		Destroy (newBar);
		Destroy(GameObject.FindGameObjectWithTag("ball"));
        Global.lives--;
		if (Global.points >= 5) {
			Global.points = Global.points - 5;
		} else {
			Global.points = 0;
		}
		Invoke ("BarSetup", 0.5f);
		FinishGame();
	}

	void BarSetup(){
		newBar = Instantiate(bar, transform.position, Quaternion.identity) as GameObject;
	}

}
