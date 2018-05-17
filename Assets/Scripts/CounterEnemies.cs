using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterEnemies : MonoBehaviour {

    public Text textnumber;

    private int contenemies = 0;
	
    // Use this for initialization
	void Start () {
        contenemies = 0;
    }
	
	public void addenemie()
    {
        contenemies++;

        textnumber.text = contenemies.ToString();
    }
}
