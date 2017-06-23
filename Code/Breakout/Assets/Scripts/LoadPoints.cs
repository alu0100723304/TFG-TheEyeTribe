using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LoadPoints : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LoadData ();
	}
	
	private void LoadData ()
	{


		Text[] textos = GetComponentsInChildren<Text>();
		SavePoints.pointsInstance.Load();
		textos[0].text = SavePoints.pointsInstance.getNames();
		textos[1].text = SavePoints.pointsInstance.getPoints();
		textos [1].color = Color.green;

	}

}
