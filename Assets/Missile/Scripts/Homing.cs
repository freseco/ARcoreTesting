using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Homing : MonoBehaviour {

    public float missileVelocity= 100;
    public float turn = 20;
    public Rigidbody homingMissile ;
    public float fuseDelay;
    public GameObject missileMod;
    public ParticleSystem SmokePrefab;
    public AudioClip missileClip;
    public GameObject explotion;
    public float selftdestroydelay;

    private AudioSource AS;

    public bool destroyTarget = true;

     Vector3 GO_target;
 
void Start()
    {
        homingMissile = transform.GetComponent<Rigidbody>();
        AS=transform.GetComponent<AudioSource>();

        //it destroys itselft after
        Destroy(gameObject, selftdestroydelay);
    }

    public void FireMissile()
    {

        StartCoroutine("AutoFire");
    }

    public void FireMissile(Vector3 targetpoint)
    {
        GO_target = targetpoint;

        StartCoroutine("Fire");
    }

    void FixedUpdate()

    {
        if (homingMissile == null)
            return;

        homingMissile.velocity = transform.forward * missileVelocity;

        Quaternion targetRotation = Quaternion.LookRotation(GO_target - transform.position);

        homingMissile.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, turn));

    }

    IEnumerator AutoFire()
    {
        yield return new WaitForSeconds(fuseDelay);

        AudioSource.PlayClipAtPoint(missileClip, transform.position);

        //GO_target =  GameObject.FindGameObjectsWithTag("target")[0].transform;


        //float distance = Mathf.Infinity;

        Transform target = null;

        GameObject[] listmonster = GameObject.FindGameObjectsWithTag("monster");

        target=listmonster[Random.Range(0, listmonster.Length)].transform.GetChild(2).transform;//gets the child headpoint

        //foreach (GameObject go in GameObject.FindGameObjectsWithTag("monster"))
        //{
        //    Transform point = go.transform.GetChild(2);

        //    float diff = (point.position - transform.position).sqrMagnitude;

        //    if (diff < distance)
        //    {
        //        distance = diff;
        //        target = point;
        //    }


        //}



        if (target != null) { 
            GO_target = target.position; }
        

        yield return null;

    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(fuseDelay);

        AudioSource.PlayClipAtPoint(missileClip, transform.position);

        yield return null;

    }

    void OnCollisionEnter(Collision theCollision)
    {
        
        if (theCollision.gameObject.tag== "monster")
        {


            //SmokePrefab.emissionRate = 0.0f;
            //theCollision.contacts[0].point;

            GameObject.Find("Canvas").GetComponent<CounterEnemies>().addenemie();

            //Destroy(missileMod.gameObject);
            //yield WaitForSeconds(5);


            if (destroyTarget)
            {
               Destroy(theCollision.gameObject);
            }

          
        }


        Debug.Log("Collision with: " + theCollision.gameObject.name);

        //GameObject.Find("debugtext").transform.GetComponent<Text>().text = theCollision.gameObject.name;

          Instantiate(explotion, theCollision.contacts[0].point, new Quaternion());
          Destroy(gameObject);
    }
    
}
