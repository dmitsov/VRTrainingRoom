using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {
	MovieTexture movie;
	AudioSource auS;

	public void playVideo() {
		movie.Play ();
		auS.Play ();
	}
	
	public void pauseVideo() {
		movie.Pause ();
		auS.Pause ();
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
