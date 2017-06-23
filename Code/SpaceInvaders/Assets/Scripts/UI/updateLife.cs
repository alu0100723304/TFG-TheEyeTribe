using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Class to control life interface
/// </summary>
public class updateLife : MonoBehaviour {

    private static Image life_1;
    private static Image life_2;
    private static Image life_3;

    /// <summary>
    /// Method to initialize
    /// </summary>
    void Start () {
        life_1 = GameObject.Find("life_1").GetComponent<Image>();
        life_2 = GameObject.Find("life_2").GetComponent<Image>();
        life_3 = GameObject.Find("life_3").GetComponent<Image>();
        update();
	}

    /// <summary>
    /// Method to be called every frame 
    /// </summary>
    public static void update ()
    {
        switch (game.getLives())
        {
            case 3:
                life_3.enabled = true;
                life_2.enabled = true;
                life_1.enabled = true;
                break;
            case 2:
                life_3.enabled = false;
                life_2.enabled = true;
                life_1.enabled = true;
                break;
            case 1:
                life_3.enabled = false;
                life_2.enabled = false;
                life_1.enabled = true;
                break;
            case 0:
                life_3.enabled = false;
                life_2.enabled = false;
                life_1.enabled = false;
                break;
        }
    }
}
