using UnityEngine;
using System.Collections;

/// <summary>
/// Class to create the special enemy
/// </summary>
public class specialRespawn : MonoBehaviour {

    public GameObject specialEnemy;

    private static int probability;
    private float delay2Create = 20f;
    private float timer = 0f;
    private static int limit = 1000;

    /// <summary>
    /// Method to initialize
    /// </summary>
    void Start () {
        updateProbability();
	}

    /// <summary>
    /// Method to be called every frame in the last position of the updates
    /// </summary>
    void LateUpdate () {
        if (delay2Create <= timer)
        {
            int aux = Random.Range(0, limit);
            if (aux < probability)
            {
                Instantiate(specialEnemy, transform.position, transform.rotation);
                timer = 0f;
            }
        }
        else
        {
            timer += Time.deltaTime;
        }
        
	}

    /// <summary>
    /// Method to update probability to create a special enemy
    /// </summary>
    public static void updateProbability ()
    {
        probability = 1 * enemy.n_games;
        if (probability > limit)
        {
            probability = limit;
        }
    }
}
