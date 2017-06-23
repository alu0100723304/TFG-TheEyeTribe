using UnityEngine;
using System.Collections;

public class changeResolution : MonoBehaviour {

    public GameObject father;
	
	void Awake ()
    {
        float aux = GetComponent<Camera>().aspect;
        father.transform.localScale = new Vector3(aux, 1f, 1f);
    }

}
