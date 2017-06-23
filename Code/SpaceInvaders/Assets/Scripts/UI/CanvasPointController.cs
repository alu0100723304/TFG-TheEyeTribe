using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class CanvasPointController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LoadData();
    }
	
    private void LoadData ()
    {
        Text[] textos = GetComponentsInChildren<Text>();

        Points.stateGame.Load();
        textos[1].text = Points.stateGame.getNames();
        textos[2].text = Points.stateGame.getPoints();
    }

	public void Back ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Delete ()
    {
        Points.stateGame.DeleteData();
        LoadData();
    }
}
