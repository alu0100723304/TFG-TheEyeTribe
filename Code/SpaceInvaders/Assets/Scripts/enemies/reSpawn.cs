using UnityEngine;
using System.Collections;

/// <summary>
/// Class to revive all enemies
/// </summary>
public class reSpawn : MonoBehaviour {

    private static GameObject[] enemies;

    // Use this for initialization
    void Start () {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
    }
	
    /// <summary>
    /// Method to revive all enemies
    /// </summary>
    public static void revive ()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].transform.position = enemies[i].GetComponent<enemy>().getFirstPosition();
            enemies[i].GetComponent<enemy>().alive();
            enemies[i].SetActive(true);
        }
    }
}
