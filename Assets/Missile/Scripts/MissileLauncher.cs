using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour {

    private bool shoot = false;
    public Transform ARcamera;

    public List<Transform> pointslaunch = new List<Transform>();

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
            GameObject newob = CreateNewMissile();

            newob.GetComponent<Homing>().FireMissile(targetpoint);
        }
    }

    private GameObject CreateNewMissile()
    {
        //new missile
        return Instantiate(missile,pointslaunch[Random.Range(0, pointslaunch.Count)].transform.position, transform.rotation).gameObject;
    }

    public void Firestraigh()
    {
        if (numEnemies() > 0)
        {
            //new missile
            GameObject newob = CreateNewMissile();

            newob.GetComponent<Homing>().FireMissile( ARcamera.position + ARcamera.forward * 5);
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
