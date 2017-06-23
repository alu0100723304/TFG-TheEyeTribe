using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Collections;


public class ShowPointController : MonoBehaviour {

    public float timeLimit = 0.5f;
    public GameObject objectObserved = null;

    private float counter = 0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        List<RaycastResult> results = Controller.Instance.Raycast2Canvas(this.gameObject);

        if (results.Count > 0)
        {
            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].gameObject.name == "back")
                {
                    if (objectObserved == results[i].gameObject)
                    {
                        if (counter >= timeLimit)
                        {
                            counter = 0;
                            GameObject.Find("score").GetComponentInChildren<CanvasPointController>().Back();
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
                else if (results[i].gameObject.name == "delete")
                {
                    if (objectObserved == results[i].gameObject)
                    {
                        if (counter >= timeLimit)
                        {
                            counter = 0;
                            GameObject.Find("score").GetComponentInChildren<CanvasPointController>().Delete();
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
                else
                {
                    if (objectObserved != null)
                    {
                        objectObserved.GetComponent<BotonController>().DisableFeedBack();
                    }
                    counter = 0;
                    objectObserved = null;
                }
            }
        }
    }


}
