using UnityEngine;
using System.Collections;

public class game : MonoBehaviour {

    private static int lives = 3;
    private static float timeScale;

    /// <summary>
    /// Method to initialize
    /// </summary>
    void Start () {
        timeScale = Time.timeScale;
        updateLife.update();
    }
	
    /// <summary>
    /// Method to kill the player 
    /// </summary>
    public static void die ()
    {
        if (lives > 0)
        {
            lives--;
            updateLife.update();
        }

        if (lives <= 0)
        {
            gameOver();
        }
    }

    /// <summary>
    /// Method to end the game
    /// </summary>
    public static void gameOver ()
    {
        lives = 0;
        updateLife.update();
        enemy.gameOver();
        //Time.timeScale = 0;
        updateGameOver.show();
    }

    /// <summary>
    /// Method to start the game
    /// </summary>
    public static void startGame ()
    {
        add();
        add();
        add();
        //Time.timeScale = timeScale;
    }

    /// <summary>
    /// Method to add one life
    /// </summary>
    public static void add ()
    {
        if (lives < 3)
        {
            lives++;
            updateLife.update();
        }
    }

    /// <summary>
    /// Method to return player lives
    /// </summary>
    /// <returns>
    /// Player lives
    /// </returns>
    public static int getLives ()
    {
        return lives;
    }
}
