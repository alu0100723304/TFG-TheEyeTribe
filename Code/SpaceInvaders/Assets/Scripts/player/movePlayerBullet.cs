using UnityEngine;
using System.Collections;

public class movePlayerBullet : MonoBehaviour {
    public float speed = 2f;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(0, speed * Time.deltaTime, 0);
	}

    void OnTriggerEnter(Collider collider)
    {
        if ((collider.tag == "roof") || (collider.tag == "Enemy"))
        {
            Destroy (this.gameObject);
        }

        if (collider.tag == "defense")
        {
            Destroy(collider.gameObject);
            Destroy (this.gameObject);
        }
    }
}
