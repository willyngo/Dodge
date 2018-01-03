using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	private LineRenderer lineRenderer;

	public Transform laserHit;

	public float timer = 3f;

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.enabled = true;
		lineRenderer.useWorldSpace = true;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.up);
		Debug.DrawLine (transform.position, hit.point);
		laserHit.position = hit.point;
		lineRenderer.SetPosition (0, transform.position);
		lineRenderer.SetPosition (1, laserHit.position);

		// Check if the laser hits the player.
		if (hit.transform.gameObject.tag.Equals ("Player", System.StringComparison.InvariantCultureIgnoreCase)) {
			hit.transform.gameObject.GetComponent<Player> ().ReceiveDamage ();
		}
	}
}
