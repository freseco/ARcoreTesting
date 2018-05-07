using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeftDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, Random.Range(2f, 4f));
	}
	
	
}
