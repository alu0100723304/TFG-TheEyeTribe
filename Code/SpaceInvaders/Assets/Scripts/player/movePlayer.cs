using UnityEngine;
using System.Collections;
using TETCSharpClient;
using TETCSharpClient.Data;

public class movePlayer : MonoBehaviour//, IGazeListener
{

    public float speed = 10f;

    private float diference;
    private CharacterController controller;
    private Color color;
    private Shader shader;
    private bool invincibility;
    private float timerInvincibility = 0;
    private float timeInvincibility = 5f;

    // Use this for initialization
    void Start()
    {
        diference = 76.44f - 57.5f + 11;
        controller = GetComponent<CharacterController>();
        shader = GetComponent<MeshRenderer>().material.shader;
        color = GetComponent<MeshRenderer>().material.color;
        invincibility = false;

        /*if (!GazeManager.Instance.IsActivated)
        {
            GazeManager.Instance.Activate
            (
             GazeManager.ApiVersion.VERSION_1_0,
             GazeManager.ClientMode.Push
            );
        }

        GazeManager.Instance.AddGazeListener (this);*/
    }

    // Update is called once per frame
    void Update()
    {
            Vector3 positionMouse = Controller.Instance.GetPosition();
            Vector3 positionPlayer = transform.position - new Vector3 (diference, 0, 0);
            Vector3 movement = new Vector3 (speed * Time.deltaTime, 0, 0);
            float aux = GetComponent<Renderer> ().bounds.extents.x;

            if ( positionMouse.x - positionPlayer.x > (aux/10))
            {
                // Move Right
                controller.Move (movement);
            }
            else if ( positionMouse.x - positionPlayer.x < -aux/1.5)
            {
                // Move Left
                controller.Move (-1 * movement);
            }
       

        if (invincibility)
        {
            timerInvincibility += Time.deltaTime;

            if (timerInvincibility >= timeInvincibility)
            {
                invincibilityOff ();
            }
        }

        // QUITAR
        if (Input.GetKeyDown (KeyCode.M))
        {
            game.gameOver();
        }


    }

    private void die ()
    {
        game.die();
        invincibilityOn ();
    }

    private void invincibilityOn ()
    {
        invincibility = true;
        GetComponent<MeshRenderer>().material.shader = Shader.Find("Transparent/Diffuse");
        GetComponent<MeshRenderer>().material.color = new Color(0, 255, 0, 0.2f);
    }

    private void invincibilityOff ()
    {
        timerInvincibility = 0;
        invincibility = false;
        GetComponent<MeshRenderer>().material.shader = shader;
        GetComponent<MeshRenderer>().material.color = color;
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.collider.tag == "enemy")
        {
            game.gameOver();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if ((collider.tag == "EnemyBullet"))
        {
            if (!invincibility)
                die();
        }
    }

    /*public void OnGazeUpdate (GazeData gazeData)
    {
        //Add frame to GazeData cache handler
        GazeDataValidator.Instance.Update (gazeData);
    }

    void OnApplicationQuit ()
    {
        GazeManager.Instance.RemoveGazeListener (this);
        GazeManager.Instance.Deactivate ();
    }*/
}
