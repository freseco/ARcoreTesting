using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour {

   
    /// <summary>
    /// 
    /// </summary>
    public Rigidbody missile;
	
	// Update is called once per frame
	public void Fire () {
       
          GameObject newob=  Instantiate(missile, transform.position, transform.rotation).gameObject;

          newob.GetComponent<Homing>().FireMissile();
	}
}
