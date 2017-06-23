using UnityEngine;
using System.Collections;
using TETCSharpClient;


public class StartConnection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
			GazeManager.Instance.Activate
			(
				GazeManager.ApiVersion.VERSION_1_0,
				GazeManager.ClientMode.Push
			);


	}

}
