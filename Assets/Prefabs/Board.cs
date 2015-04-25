using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {
	MovieTexture movie;
	AudioSource auS;

	public void loadVideo(string name) {
		Renderer r = GetComponentInChildren<Renderer>();
		movie = (MovieTexture)Resources.Load(name + "V");
		r.material.mainTexture = movie;

		AudioSource audS = GetComponentInChildren<AudioSource>();
		AudioClip audClip = (AudioClip)Resources.Load(name + "A");
		audS.clip = audClip;

		//pauseVideo();
	}

	public void playVideo() {
		movie.Play ();
		auS.Play ();
	}
	
	public void pauseVideo() {
		movie.Pause ();
		auS.Pause ();
	}

	public void stopVideo() {
		movie.Stop ();
		auS.Stop ();
	}
	
	void Start () {
		Renderer r = gameObject.GetComponentInChildren<Renderer>();
		movie = (MovieTexture)r.material.mainTexture;
		movie.Pause ();
		auS = gameObject.GetComponentInChildren<AudioSource>();
		auS.Pause ();
	}
	
	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			if(movie.isPlaying){
				pauseVideo();
			}
			else {
				playVideo();
			}
		}
	}
}
