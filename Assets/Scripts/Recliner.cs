﻿using UnityEngine;
using System.Collections;

public class Recliner : MonoBehaviour {
	public GameObject disarmed;
	public GameObject back;
	public float throwSpeed = 1f;

	private bool active = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag == "Floor") {
			return;
		}
		if (active) {
			Vector3 force = Quaternion.AngleAxis (45, transform.forward) * transform.right;
			coll.gameObject.GetComponent<Rigidbody> ().AddForce(force*throwSpeed, ForceMode.Impulse);
			active = false;
		}
		StartCoroutine ("Fling");

	}

	IEnumerator Fling(){
		for (float i = 45; i > 0; --i) {
			back.transform.localRotation = Quaternion.Euler ( new Vector3 (0f, 0f, i));
			yield return null;
		}
	}
}