using UnityEngine;
using System.Collections;

public class ListBox : MonoBehaviour 
{
	public string[] items;
	public Rect Box;

	private string selectedItem = "None";
	private bool editing = false;

	private void OnGUI()
	{
		if(GUI.Button(Box,selectedItem))
		{
			editing = true;
		}

		if(editing)
		{
			for(int x = 0; x < items.Length; x++)
			{
				if(GUI.Button(new Rect(Box.x,(Box.height * x) + Box.y + Box.height, Box.width,Box.height), items[x]))
				{
					selectedItem = items[x];
					editing = false;
				}
			}
		}
	}
}
