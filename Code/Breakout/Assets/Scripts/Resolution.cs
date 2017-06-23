using UnityEngine;
using System.Collections;

public class Resolution : MonoBehaviour {

	public GameObject father;

	// Use this for initialization
	void Awake () {
		float aux = GetComponent<Camera> ().aspect;
		father.transform.localScale = new Vector3 (aux, 1f, 1f);
	}
}
