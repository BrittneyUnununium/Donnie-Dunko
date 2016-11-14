using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	private static SoundManager _instance = new SoundManager();
	public static SoundManager Instance { get { return _instance; } }


	public AudioClip [] sounds;



	int SearchClips(string name) {
		for (int i=0; i < sounds.Length; i++) {
			if(sounds[i].name == name) {
				return i;
			}
		}
		Debug.LogError ("ERROR: SOUND FILE NAMED " + name + " NOT FOUND IN SoundManager");
		return -1;
	}

	public void PlaySound(string soundName) {
		if (SearchClips(soundName) != -1) {
			AudioSource.PlayClipAtPoint (sounds [SearchClips (soundName)], this.transform.position);
		}
	}

	public void PlaySound(string soundName, bool changePitch, float min, float max) {
		if (SearchClips(soundName) != -1) {


			// MAY WANT TO CHANGE THIS LATER TO SAVE ON OVERHEAD
			AudioSource source = this.gameObject.GetComponent<AudioSource>();
			////////////////////////////////////////////////////
			source.pitch = 1 + Random.Range(min, max);
			//source.PlayClipAtPoint (sounds [SearchClips (soundName)], this.transform.position);
			source.clip = sounds[SearchClips (soundName)];
			source.PlayOneShot(source.clip);
		}
	}


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void Awake() { _instance = this; }
}
