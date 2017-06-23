using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using TETCSharpClient;
using TETCSharpClient.Data;

public class Controller : MonoBehaviour, IGazeListener
{
    public static Controller Instance;
    public bool mouse { get; set; }

	// Use this for initialization
	void Start () {
        #region "Singleton method"
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion

        if ( !GazeManager.Instance.IsActivated )
            {
                GazeManager.Instance.Activate
                (
                 GazeManager.ApiVersion.VERSION_1_0,
                 GazeManager.ClientMode.Push
                );
            }

        GazeManager.Instance.AddGazeListener (this);
        mouse = true;
    }


    public List<RaycastResult> Raycast2Canvas (GameObject canvas)
    {
        GraphicRaycaster graphic = canvas.GetComponent<GraphicRaycaster>();
        PointerEventData point = new PointerEventData(null);
        Camera Camera = GameObject.Find ("Main Camera").GetComponent<Camera> ();
        if ( Camera == null )
        {
            throw new System.ArgumentException ("Camera not found");
        }

        if (!mouse )
        {
            Point2D gazeCoords = GazeDataValidator.Instance.GetLastValidSmoothedGazeCoordinates ();
            // Map gaze indicator
            Point2D gp = UnityGazeUtils.GetGazeCoordsToUnityWindowCoords(gazeCoords);
            point.position = new Vector3((float)gp.X, (float)gp.Y, Camera.nearClipPlane + 1f);
        }
        else
        {
            point.position = Input.mousePosition;
        }


        List<RaycastResult> results = new List<RaycastResult>();
        graphic.Raycast(point, results);

        EventSystem.current.RaycastAll(point, results);

        return results;
    }

    public Vector3 GetPosition ()
    {
        Vector3 positionMouse;
        Camera positionCamera = GameObject.Find ("Main Camera").GetComponent<Camera> ();
        if ( positionCamera == null )
        {
            throw new System.ArgumentException ("Camera not found");
        }

        if (!mouse )
        {
            Point2D gazeCoords = GazeDataValidator.Instance.GetLastValidSmoothedGazeCoordinates ();
            // Map gaze indicator
            Point2D gp = UnityGazeUtils.GetGazeCoordsToUnityWindowCoords (gazeCoords);
            positionMouse = new Vector3 ((float)gp.X, (float)gp.Y, 0);
            positionMouse = Camera.main.ScreenToWorldPoint (positionMouse);
            if ( Points.stateGame.saveData )
                Points.stateGame.Save ((float)gp.X, (float)gp.Y);
        }

        else
        {
            positionMouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionCamera.nearClipPlane + 1f));
        }

        return positionMouse;
    }

    public void OnGazeUpdate (GazeData gazeData)
    {
        //Add frame to GazeData cache handler
        GazeDataValidator.Instance.Update (gazeData);
    }

    void OnApplicationQuit ()
    {
        GazeManager.Instance.RemoveGazeListener (this);
        GazeManager.Instance.Deactivate ();
    }

}
