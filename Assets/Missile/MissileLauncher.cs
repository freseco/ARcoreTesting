using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour {

   
    /// <summary>
    /// 
    /// </summary>
    public Rigidbody missile;
	
    private int numEnemies()
    {
        return GameObject.FindGameObjectsWithTag("monster").Length;
        
        }

	// Update is called once per frame
	public void Fire () {

        if (numEnemies()>0)
        {
            //new missile
            GameObject newob = Instantiate(missile, transform.position, transform.rotation).gameObject;

            newob.GetComponent<Homing>().FireMissile(); 
        }
	}

    public void Fire(Vector3 targetpoint)
    {

        if (numEnemies() > 0)
        {
            //new missile
            GameObject newob = Instantiate(missile, transform.position, transform.rotation).gameObject;

            newob.GetComponent<Homing>().FireMissile(targetpoint);
        }
    }
}
