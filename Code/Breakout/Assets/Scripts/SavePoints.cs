using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Collections.Generic;
using BreakOut;

public class SavePoints : MonoBehaviour {
	private static string fileWay;
	private ArrayList playerPoints;
	public static SavePoints pointsInstance;
	// Use this for initialization
	void Start () {
		playerPoints = new ArrayList();
		if (pointsInstance == null) {
			pointsInstance = this;
			//DontDestroyOnLoad (gameObject);
			fileWay = Application.persistentDataPath + "/points.dat";
		} 
		else {
			Destroy (gameObject);
		}
	}

	public string getNames ()
	{
		string aux = "";

		foreach (PlayerPoints player in playerPoints)
		{
			aux += player.getPlayerName() + "\n";
		}

		return aux;
	}

	public string getPoints ()
	{
		string aux = "";

		foreach (PlayerPoints player in playerPoints)
		{
			aux += player.getPoints() + "\n";
		}

		return aux;
	}

	public void Save (PlayerPoints points)
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
		
	[Serializable]
	class Data2Save
	{
		public ArrayList points2Save;

		public Data2Save (ArrayList points2Save)
		{
			this.points2Save = points2Save;
		}
	}
}
