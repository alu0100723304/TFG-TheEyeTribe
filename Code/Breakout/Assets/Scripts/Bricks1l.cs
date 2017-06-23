using UnityEngine;
using System.Collections;

public class Bricks1l : MonoBehaviour {

	void OnCollisionEnter(){
		GM.instance.DestroyBrick();
		Destroy(gameObject);
	}
}
