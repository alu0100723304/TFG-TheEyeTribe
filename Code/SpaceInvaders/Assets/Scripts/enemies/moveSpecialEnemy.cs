using UnityEngine;
using System.Collections;

/// <summary>
/// Class to move the special enemy
/// </summary>
public class moveSpecialEnemy : MonoBehaviour {

    public float speed = 100f;
    public int points = 200;

    /// <summary>
    /// Method to initialize
    /// </summary>
    void Start () {
	
	}

    /// <summary>
    /// Method to be called every frame checking physics
    /// </summary>
    void FixedUpdate () {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    /// <summary>
    /// Method to check collision vs righbodies
    /// </summary>
    void OnCollisionEnter(Collision collider)
    {
        if (collider.collider.tag == "destructor")
        {
            Destroy(this.gameObject);
        }
    }

            void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "PlayerBullet")
        {
            updatePoints.add(points);
            Destroy(this.gameObject);
        }
    }
}
