using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VisualKeyboardController : MonoBehaviour {

    public Text text;
    public KeysController keys;
    public updateGameOver interfaz;


	// Use this for initialization
	void Start () {
        text.text = "";
        keys.TurnOnVisualKeyboard();
        keys.interfaz = this;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        text.text = keys.getText();
	}

    public void EndVisualKeyboard ()
    {
        interfaz.EndVisualKeyboard(keys.getText());
    }
}
