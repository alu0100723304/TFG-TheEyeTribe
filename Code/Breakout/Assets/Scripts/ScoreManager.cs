using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TETCSharpClient;
using TETCSharpClient.Data;


public class ScoreManager : MonoBehaviour, IGazeListener {
	private float waitTimeButtons = .3f;
	private float delay;
	Camera CamaraPosition;
	private Text backText;

	// Use this for initialization
	void Start () {
		delay = 0f;
		GazeManager.Instance.AddGazeListener(this);
		CamaraPosition = GameObject.Find ("Main Camera").GetComponent<Camera>();
		backText = GameObject.Find ("Back").GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		Point2D gazeCoords = GazeDataValidator.Instance.GetLastValidSmoothedGazeCoordinates();
		GraphicRaycaster gr = this.GetComponent<GraphicRaycaster>();
		//Current pointer position
		PointerEventData point = new PointerEventData(null);

		if (!Global.useMouse) {
			Point2D gp = UnityGazeUtils.GetGazeCoordsToUnityWindowCoords (gazeCoords);
			point.position = new Vector3 ((float)gp.X, (float)gp.Y, CamaraPosition.nearClipPlane + 1f);
		} 

		else {
			point.position = Input.mousePosition;
		}

		//result will contain all of the hit canvas
		List<RaycastResult> results = new List<RaycastResult> ();
		gr.Raycast (point, results);

		if (results.Count > 0) {				
				if (results [0].gameObject.name == "Back") {
					backText.color = Color.green;
					if (delay > waitTimeButtons) {
						SceneManager.LoadScene ("MainMenu");
					} else {
						delay += Time.deltaTime;
					}
				} else {
					backText.color = Color.white;
					delay = 0;
				}


		}
	}



	public void OnGazeUpdate(GazeData gazeData)
	{
		//Debug.Log ("entreeee");
		//Add frame to GazeData cache handler
		GazeDataValidator.Instance.Update(gazeData);
	}

	void OnApplicationQuit()
	{
		GazeManager.Instance.RemoveGazeListener(this);
		GazeManager.Instance.Deactivate();
	}
}

