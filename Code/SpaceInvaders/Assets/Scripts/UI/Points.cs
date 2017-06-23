using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Collections.Generic;
using SpaceInvaders;

public class Points : MonoBehaviour {

    private ArrayList playerPoints;
    private MedicData medicData;
    private static string fileWay;
    private static string medicFileWay;
    private StreamWriter stream = null;
    public bool saveData = true;
    public static Points stateGame;

	// Use this for initialization
	void Awake () {
        playerPoints = new ArrayList();
        fileWay = Application.persistentDataPath + "/points.dat";
        medicFileWay = Path.GetFileName(@"/MedicDataSI.txt");
        Debug.Log(medicFileWay);

        #region "Singleton method"
        if (stateGame == null)
        {
            stateGame = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
    }

    void Start ()
    {
        try
        {
            if ( stream == null )
            {
                stream = File.AppendText (medicFileWay);
            }
        }
        catch ( IOException exception )
        {
            Debug.LogError ("Error opening the medic file: " + exception.Message);
        }
        catch ( NotSupportedException exception )
        {
            Debug.LogError ("Unknown Error: " + exception.Message);
        }
    }

    // Update is called once per frame
    void Update () {
	
	}

    /// <summary>
    /// Method to get all names like a string
    /// </summary>
    /// <returns>String with all names</returns>
    public string getNames ()
    {
        string aux = "";

        foreach (PlayerPoint player in playerPoints)
        {
            aux += player.getNamePlayer() + "\n";
        }

        return aux;
    }

    /// <summary>
    /// Method to get all points like a string
    /// </summary>
    /// <returns>String with all points</returns>
    public string getPoints ()
    {
        string aux = "";

        foreach (PlayerPoint player in playerPoints)
        {
            aux += player.getPoints() + "\n";
        }

        return aux;
    }

    /// <summary>
    /// Method to save points in a file
    /// </summary>
    /// <param name="points">Points to save</param>
    public void Save (PlayerPoint points)
    {
        Load();
        playerPoints.Add(points);
        playerPoints.Sort();
        playerPoints.Reverse();
        BinaryFormatter bf = new BinaryFormatter();
        try
        {
            FileStream file = File.Create(fileWay);

            Data2Save data = new Data2Save(playerPoints);
            bf.Serialize(file, data);

            file.Close();
        }
        catch (IOException exception)
        {
            Debug.LogError("Error saving: " + exception.Message);
        }
    }

    /// <summary>
    /// Method to save eyes positions in a file
    /// </summary>
    /// <param name="data">Data to save</param>
    public void Save (float x, float y)
    {
        DateTime ThisDay = DateTime.Now;
        stream.WriteLine(x + ";" + y + ";" + ThisDay.ToString("dd;M;yyyy;HH;mm;ss.fff"));
    }

    /// <summary>
    /// Methos to load points from a file
    /// </summary>
    public void Load ()
    {
        BinaryFormatter bf = new BinaryFormatter();
        try
        {
            if (File.Exists(fileWay))
            {
                FileStream file = File.Open(fileWay, FileMode.Open);

                Data2Save data = (Data2Save)bf.Deserialize(file);

                playerPoints = data.points2Save;

                file.Close(); 
            }
            else
            {
                Debug.Log("No file to load");
            }
        }
        catch (IOException exception)
        {
            Debug.LogError("Error loading: " + exception.Message);
        }
    }

    /// <summary>
    /// Method to delete data
    /// </summary>
    public void DeleteData ()
    {
        playerPoints.Clear();
        BinaryFormatter bf = new BinaryFormatter();
        try
        {
            FileStream file = File.Create(fileWay);

            Data2Save data = new Data2Save (playerPoints);
            bf.Serialize(file, data);

            file.Close();
        }
        catch (IOException exception)
        {
            Debug.Log("Error deleting: " + exception.Message);
        }
    }

    [Serializable]
    class Data2Save
    {
        public ArrayList points2Save;

        public Data2Save (ArrayList points2Save)
        {
            this.points2Save = points2Save;
        }
    }

    void OnApplicationQuit ()
    {
        Debug.Log ("Salio");
        if (stream != null)
        {
            stream.Close ();
        }
    }

    public void OnPressedToggle ()
    {
        Debug.Log ("ENTRO");
        if ( saveData ) saveData = false;
        else saveData = true;
    }
}
