using UnityEngine;
using System.Collections;
using Ovr;


public class OculusScript : MonoBehaviour {
	private OVRCameraRig OculusCamera = null;
	private OVRCrosshair Crosshair;

	void Awake () {
		OculusCamera = GetComponentsInParent<OVRCameraRig>()[0];
	}

	void Start(){
		Crosshair = new OVRCrosshair();
		UnityEngine.Texture crossText = Resources.Load <UnityEngine.Texture>(".\\Assets\\Plugins\\FPS Constructor V1\\Demo Assets\\Source\\Textures\\Crosshair\\Crosshair.png");
		Crosshair.SetCrosshairTexture (ref crossText);
		Crosshair.SetOVRCameraController(ref OculusCamera);

	}

	void Update () {

/*		GameObject cube = GameObject.Find ("Cube1");
		if (cube == null) {
			Debug.LogWarning ("Cant find the cube!");
			return;
		}
		Vector3 cubeDirection = cube.transform.position - transform.position;
		float angleBetween = Vector3.Angle(LookAheadVector, cubeDirection);
		string warning = "Angle: " + angleBetween;
		Debug.LogWarning (warning);
		if (angleBetween <= 1.0f) {
			GameObject copy = GameObject.CreatePrimitive (PrimitiveType.Cube);
			copy.transform.position = new Vector3(cube.transform.position.x - 1.0f,cube.transform.position.y, cube.transform.position.z);
	
		}*/
	}
}
