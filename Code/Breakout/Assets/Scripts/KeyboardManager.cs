using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TETCSharpClient;
using TETCSharpClient.Data;

public class KeyboardManager : MonoBehaviour,  IGazeListener {
	public static KeyboardManager keyboardManager;
	private float waitTime = 0.9f;
	private string text = "";
	private float delay;
	Camera CamaraPosition;
	private Text nameText;
	private Color bColor = new Color32(174, 181, 181, 255);
	private GameObject objectObserved;
	// Use this for initialization
	void Start () {
		if (keyboardManager == null) {
			keyboardManager = this;
			DontDestroyOnLoad (gameObject);
		} 
		else {
			Destroy (gameObject);
		}
		text = "";
		delay = 0f;
		GazeManager.Instance.AddGazeListener(this);
		CamaraPosition = GameObject.Find ("Main Camera").GetComponent<Camera>();
		nameText = GameObject.Find ("Name").GetComponent<Text>();
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
			for (int i = 0; i < results.Count; i++) {

				if (results [i].gameObject.name == "Save") {
					results [i].gameObject.GetComponent<Image> ().color = Color.green;
					objectObserved.gameObject.GetComponent<Image> ().color = Color.green;
					if (delay > waitTime) {
						SceneManager.LoadScene ("FinishGame"); 
					} else {
						delay += Time.deltaTime;
					}
				} else {
					GameObject.Find ("Save").gameObject.GetComponent<Image> ().color = bColor;
				}

				if (results [i].gameObject.name == "Delete") {
					results [i].gameObject.GetComponent<Image> ().color = Color.green;
					if (delay > waitTime) {
						try {
							text = text.Substring (0, text.Length - 1);
							nameText.text = text;

							delay = 0;
						} catch (System.Exception e) {
							text = "";
							delay = 0;
						}
					} else {
						delay += Time.deltaTime;
					}
				} else {
					GameObject.Find ("Delete").gameObject.GetComponent<Image> ().color = bColor;
				}

				if (results [i].gameObject.name == "Space") {
					results [i].gameObject.GetComponent<Image> ().color = Color.green;
					if (delay > waitTime) {
						text = text + " ";
						delay = 0;
					} else {
						delay += Time.deltaTime;
					}
				} else {
					GameObject.Find ("Space").gameObject.GetComponent<Image> ().color = bColor;
				}

				if (results [i].gameObject.name == "letter") {
					objectObserved = results [i].gameObject;
					objectObserved.gameObject.GetComponent<Image> ().color = Color.green;
					if (delay > waitTime) {
						text += results [i].gameObject.GetComponentInChildren<Text> ().text;
						nameText.text = text;
						delay = 0;

					} else {
						delay += Time.deltaTime;
					}
				} else {
					if (objectObserved != null && results [i].gameObject != objectObserved) {
						objectObserved.GetComponent<Image> ().color = bColor;
					}
				}
			}
		}
	
	}

	public string getText(){
		return text;
	}

	public void setText(string tex){
		this.text = tex;
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
