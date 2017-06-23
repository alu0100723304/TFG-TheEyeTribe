using UnityEngine;
using System.Collections;

public class Bricks3l : MonoBehaviour {

    public GameObject Brick;
    private GameObject newBrick;

	void OnCollisionEnter(){
		Vector3 scale = transform.localScale;
		newBrick = Instantiate(Brick, transform.position, Quaternion.identity) as GameObject;
		newBrick.transform.parent = transform.parent;
		newBrick.transform.localScale = scale;
		GM.instance.DestroyBrick();
		Destroy(gameObject);
    }
}
