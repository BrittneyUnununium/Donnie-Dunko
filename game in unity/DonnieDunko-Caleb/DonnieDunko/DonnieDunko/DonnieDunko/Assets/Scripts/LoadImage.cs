using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LoadImage : MonoBehaviour
{

	public string file_path; //path to load image from
	private DirectoryInfo info;
	
	// Use this for initialization
	void Start ()
	{
		info = new DirectoryInfo(@"C:\");
	}
	
	// Update is called once per frame
	void Update ()
	{
	   foreach(FileInfo file in info.GetFiles())
		{
			Debug.Log(file.FullName);
		}

	  FileStream fileStream = new FileStream(file_path,FileMode.Open);

	  if(file_path == null)
	  {
		 print("No file selected");
	  }
	}
}

