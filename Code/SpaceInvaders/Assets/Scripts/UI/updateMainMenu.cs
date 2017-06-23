using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Collections;
using TETCSharpClient;
using TETCSharpClient.Data;

public class updateMainMenu : MonoBehaviour
{

    public float timeLimit = 0.5f;
    public GameObject objectObserved = null;

    private float counter = 0f;

    void Start ()
    {
        /*if ( !GazeManager.Instance.IsActivated )
        {
            GazeManager.Instance.Activate
            (
             GazeManager.ApiVersion.VERSION_1_0,
             GazeManager.ClientMode.Push
            );
        }*/

        //GazeManager.Instance.AddGazeListener (this);
    }

    /// <summary>
    /// Method to start the game
    /// </summary>
    public void startLevel ()
    {
        SceneManager.LoadScene("Nivel_1");
    }

    /// <summary>
    /// Method to exit the game
    /// </summary>
    public void exitGame ()
    {
        Application.Quit();
    }

    /// <summary>
    /// Methos to show the points
    /// </summary>
    public void pointsLevel ()
    {
        SceneManager.LoadScene("ShowPoints");
    }

    void Update()
    {
        List<RaycastResult> results = Controller.Instance.Raycast2Canvas(this.gameObject);

        if (results.Count > 0)
        {
            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].gameObject.name == "play")
                {
                    if (objectObserved == results[i].gameObject)
                    {
                        if (counter >= timeLimit)
                        {
                            counter = 0;
                            startLevel();
                            break;
                        }
                        else
                        {
                            counter += Time.deltaTime;
                            break;
                        }
                    }
                    else
                    {
                        counter = 0;
                        if (objectObserved != null)
                        {
                            objectObserved.GetComponent<BotonController>().DisableFeedBack();
                        }
                        objectObserved = results[i].gameObject;
                        results[i].gameObject.GetComponent<BotonController>().FeedBack();
                        break;
                    }
                }
                else if (results[i].gameObject.name == "exit")
                {
                    if (objectObserved == results[i].gameObject)
                    {
                        if (counter >= timeLimit)
                        {
                            counter = 0;
                            exitGame();
                            break;
                        }
                        else
                        {
                            counter += Time.deltaTime;
                            break;
                        }
                    }
                    else
                    {
                        counter = 0;
                        if (objectObserved != null)
                        {
                            objectObserved.GetComponent<BotonController>().DisableFeedBack();
                        }
                        objectObserved = results[i].gameObject;
                        results[i].gameObject.GetComponent<BotonController>().FeedBack();
                        break;
                    }
                }
                else if (results[i].gameObject.name == "points")
                {
                    if (objectObserved == results[i].gameObject)
                    {
                        if (counter >= timeLimit)
                        {
                            counter = 0;
                            pointsLevel();
                            break;
                        }
                        else
                        {
                            counter += Time.deltaTime;
                            break;
                        }
                    }
                    else
                    {
                        counter = 0;
                        if (objectObserved != null)
                        {
                            objectObserved.GetComponent<BotonController>().DisableFeedBack();
                        }
                        objectObserved = results[i].gameObject;
                        results[i].gameObject.GetComponent<BotonController>().FeedBack();
                        break;
                    }
                }

                else if ( results [i].gameObject.name == "Toggle" )
                {
                    if ( objectObserved == results [i].gameObject )
                    {
                        if ( counter >= timeLimit )
                        {
                            
                            if ( Points.stateGame.saveData == false )
                                objectObserved.GetComponentInChildren<Toggle> ().isOn = true;
                            else
                                objectObserved.GetComponentInChildren<Toggle> ().isOn = false;

                            counter = 0;
                            break;
                        }
                        else
                        {
                            counter += Time.deltaTime;
                            break;
                        }
                    }
                    else
                    {
                        counter = 0;
                        if ( objectObserved != null )
                        {
                            objectObserved.GetComponent<BotonController> ().DisableFeedBack ();
                        }
                        objectObserved = results [i].gameObject;
                        results [i].gameObject.GetComponent<BotonController> ().FeedBack ();
                        break;
                    }
                }

                else
                {
                    if ( objectObserved != null )
                    {
                        objectObserved.GetComponent<BotonController> ().DisableFeedBack ();
                        if (objectObserved.gameObject.name != "Toggle" )
                        {
                            counter = 0;
                            objectObserved = null;
                        }
                    }
                    else
                    {
                        counter = 0;
                        objectObserved = null;
                    }
                    
                }
            }
        }
    }

    /*public void OnGazeUpdate (GazeData gazeData)
    {
        //Add frame to GazeData cache handler
        GazeDataValidator.Instance.Update (gazeData);
    }*/

    /*void OnApplicationQuit ()
    {
        GazeManager.Instance.RemoveGazeListener (this);
        GazeManager.Instance.Deactivate ();
    }*/
}
