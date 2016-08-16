using UnityEngine;
using System.Collections;

public class cubeManager : MonoBehaviour {
	private Color initialColor;

	void Start () {
		initialColor = GetComponent<Renderer> ().material.color;
	}

	//if gazed at make object green else go back to original color
	public void SetGazedAt(bool gazedAt) {
		GetComponent<Renderer>().material.color = gazedAt ? Color.green : initialColor;
	}

	//make object red
	public void hit() {
		GetComponent<Renderer> ().material.color = Color.red;
	}
}
