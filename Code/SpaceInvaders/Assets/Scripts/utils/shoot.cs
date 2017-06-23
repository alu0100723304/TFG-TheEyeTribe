using UnityEngine;
using System.Collections;

/// <summary>
/// Class to shoot some bullet in some shooter with delays and probability
/// </summary>
public class shoot : MonoBehaviour {

    public GameObject bullet;
    public GameObject shooter;
    public float delayShoot = 0.5f;
    public float delayStart = 0f;
    public bool random = false;
    public static int probability;

    private float timerShoot = 0f;
    private float timerStart = 0f;
    private static int limit = 100;

    /// <summary>
    /// Method to initialize
    /// </summary>
    void Start () {
        timerShoot = 1 + delayShoot;
        updateProbability();
	}

    /// <summary>
    /// Method to be called every frame checking physics
    /// </summary>
    void FixedUpdate () {
        if (timerStart > delayStart)
        {
            if (timerShoot > delayShoot)
            {
                if (!random)
                {
                    Instantiate(bullet, shooter.transform.position, shooter.transform.rotation);
                    timerShoot = 0f;
                }
                else
                {
                    timerShoot = 0f;
                    int aux =  Random.Range(0, limit);
                    if (aux < probability)
                    {
                        Instantiate(bullet, shooter.transform.position, shooter.transform.rotation);
                    }
                }
            }
            timerShoot += Time.deltaTime;
        }
        else
        {
            timerStart += Time.deltaTime;
        }
	}

    /// <summary>
    /// Method to update the probability to shoot
    /// </summary>
    public static void updateProbability ()
    {
        probability = 5 * enemy.n_games;
        if (probability > limit)
        {
            probability = limit;
        }
    }
}
