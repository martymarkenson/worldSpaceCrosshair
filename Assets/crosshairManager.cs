using UnityEngine;
using System.Collections;

public class crosshairManager : MonoBehaviour {
	public Transform raycastOrigin;
	public float fixedDistance;
	public GameObject crosshair;
	public bool fixedDepth;
	private float distance;
	private RaycastHit? crosshairHit;
	private RaycastHit hit;
	private Vector3 direction;

	void Start() {
		//if fixedDepth is true place crosshair at static distance
		if (fixedDepth) {
			crosshair.transform.position = Vector3.forward * fixedDistance;
		}
	}

	void Update () {
		//if !fixedDepth && raycast hits gameobject set crosshair to active at the distance of the hit else deactivate the crosshair
		if (!fixedDepth) {
			direction = gameObject.transform.position - raycastOrigin.position;
			crosshairHit = crosshairPosition ();
			if (crosshairHit.HasValue) {
				crosshair.SetActive (true);
				crosshair.transform.position = direction * crosshairHit.Value.distance;
			} else {
				crosshair.SetActive (false);
			}

		}
	}


	//if the Raycast has hit a GameObject return hit else return null
	public RaycastHit? crosshairPosition() {
		Debug.DrawRay(raycastOrigin.position, direction, Color.red, .1f, true);
		if (Physics.Raycast (raycastOrigin.position, direction, out hit)) {
			return hit;
		} else {
			return null;
		}
	}
}
