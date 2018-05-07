using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public bool destroyTarget = false;

     Transform GO_target;
 
void Start()
    {
        homingMissile = transform.GetComponent<Rigidbody>();
        AS=transform.GetComponent<AudioSource>();

        //it destroys itselft after
        Destroy(this, selftdestroydelay);
    }

    public void FireMissile()
    {
        StartCoroutine("Fire");
    }

    void FixedUpdate()

    {
        if (GO_target == null || homingMissile == null)
            return;

        homingMissile.velocity = transform.forward * missileVelocity;

        Quaternion targetRotation = Quaternion.LookRotation(GO_target.position - transform.position);

        homingMissile.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, turn));

    }

   IEnumerator Fire()
    {
        yield return new WaitForSeconds(fuseDelay);
        
        AudioSource.PlayClipAtPoint(missileClip, transform.position);

      GO_target =  GameObject.FindGameObjectsWithTag("target")[0].transform;


        //float distance = Mathf.Infinity;
        
        //foreach (GameObject go   in GameObject.FindGameObjectsWithTag("target"))
        //{
        //    float diff = (go.transform.position - transform.position).sqrMagnitude;

        //    if (diff < distance)
        //    {
        //        distance = diff;
        //        GO_target = go.transform.parent.transform;
        //    }

        //}

        yield return null;

    }

    void OnCollisionEnter(Collision theCollision)
    {
        
        if (theCollision.gameObject.tag== "target")
        {
            
            
            //SmokePrefab.emissionRate = 0.0f;
            //theCollision.contacts[0].point;

            Instantiate(explotion, theCollision.contacts[0].point, new Quaternion());

            Destroy(missileMod.gameObject);
            //yield WaitForSeconds(5);
            Destroy(gameObject);

            //if (destroyTarget)
            //    Destroy(theCollision.gameObject);
        }

        
    }
    
}
