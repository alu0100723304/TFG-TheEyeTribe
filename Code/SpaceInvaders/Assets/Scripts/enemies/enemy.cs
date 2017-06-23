using UnityEngine;
using System.Collections;

/// <summary>
/// Class to control all enemies
/// </summary>
public class enemy : MonoBehaviour {

    public int points = 10;
    public static float speed;
    public float speedDown = 5f;
    public static int n_games = 1;

    private Vector3 position;
    private static int n_enemies = 0;
    private static bool right = true;
    private static bool secure = false;

    /// <summary>
    /// Method to initialize
    /// </summary>
    void Start () {
        alive();
        position = transform.position;
        n_games = 1;
    }

    
    public static void gameOver ()
    {
        n_enemies = 0;
    }

    /// <summary>
    /// Method to be called every frame checking physics
    /// </summary>
    void FixedUpdate () {
        int aux;
        if (right)
        {
            aux = 1;
        }
        else
        {
            aux = -1;
        }

        transform.Translate(aux * speed * Time.deltaTime, 0, 0);
        if (secure)
        {
            secure = false;
        }
	}

    /// <summary>
    /// Method to move down all enemies
    /// </summary>
    public void  moveDown ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].transform.Translate(0, - speedDown, 0);
        }
    }

    /// <summary>
    /// Method to update parameters when the enemy go alive
    /// </summary>
    public void alive ()
    {
        n_enemies++;
        speed = 50 * n_games;
    }

    /// <summary>
    /// Method to return the first position
    /// </summary>
    /// <returns>
    /// First position of the enemy
    /// </returns>
    public Vector3 getFirstPosition ()
    {
        return position;
    }

    /// <summary>
    /// Method to check collision vs righbodies
    /// </summary>
    void OnCollisionEnter(Collision collider)
    {
        if (collider.collider.tag == "wall")
        {
            if (!secure)
            {
                secure = true;
                if (right)
                {
                    right = false;
                }
                else
                {
                    right = true;
                }
                moveDown();
            }
        }
    }

    /// <summary>
    /// Method to check collision vs triggers
    /// </summary>
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "PlayerBullet")
        {
            updatePoints.add(points);
            n_enemies--;

            if (n_enemies == 1)
            {
                speed = speed * 2;
                this.gameObject.SetActive(false);
            }

            else if (n_enemies <= 0)
            {
                n_games++;
                reSpawn.revive ();
                shoot.updateProbability();
                game.add();
            }

            else
            {
                this.gameObject.SetActive(false);
            }
            
            //Destroy(this.gameObject); 
        }
    }

}
