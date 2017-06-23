using UnityEngine;
using System.Collections;

public class Dead : MonoBehaviour {
	void OnTriggerEnter(){
		GM.instance.Lose();
	}
}
