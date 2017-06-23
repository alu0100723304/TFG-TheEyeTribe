using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class SaveMedicalData : MonoBehaviour {
	StreamWriter stream = null;
	public static SaveMedicalData instance;

	public string URL;
	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);
			URL = Path.GetFileName(@"/MedicDataBO.txt");
			if (stream == null) {
				stream = File.AppendText(URL);
			}
		} 
		else {
			Destroy (gameObject);
		}
	}
			
	public void Save(float x, float y) {
        DateTime ThisDay = DateTime.Now;
        stream.WriteLine(x + ";" + y + ";" + ThisDay.ToString("dd;M;yyyy;HH;mm;ss.fff"));
    }

	void OnApplicationQuit() {
		if (stream != null) {
			stream.Close ();
		}
	}
}
