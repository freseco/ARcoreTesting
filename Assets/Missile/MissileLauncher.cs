using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour {

    private bool shoot = false;

    private void Start()
    {
        StartCoroutine("firemissile");
    }

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
        shoot = true;
       
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


    IEnumerator firemissile()
    {
        while (true)
        {

            if (shoot)
            {
                shoot = false;

                if (numEnemies() > 0)
                {
                    //new missile
                    GameObject newob = Instantiate(missile, transform.position, transform.rotation).gameObject;

                    newob.GetComponent<Homing>().FireMissile();
                }
            }

            yield return new WaitForSeconds(2f);
            
        }
    }
}
