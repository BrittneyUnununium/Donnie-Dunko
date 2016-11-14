using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEditor.Events;

public class UI : MonoBehaviour {

	public UI ListBox;
	private int ListBox_Size;
	public string list_entry;
	private List <string> items;

	// Use this for initialization
	void Start () {

		ListBox_Size = 0;
		list_entry = "";

		items.Add (list_entry);
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i <= 82; i++)
		{
			items.Insert(ListBox_Size,list_entry);
		}
	}
}
