using UnityEngine;
using System.Collections;

public class WallPosition : MonoBehaviour {

	public static float rightWallX;
	public static float leftWallX;

	void Start(){
		rightWallX = GameObject.FindGameObjectWithTag("RightWall").transform.position.x - 2.05f;
		leftWallX = GameObject.FindGameObjectWithTag ("LeftWall").transform.position.x + 2.05f;
	}
}
