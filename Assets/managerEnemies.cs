using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerEnemies : MonoBehaviour {

    public GameObject enemy;

    public List<GameObject> points= new List<GameObject>();

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (numEnemies() == 0) GenerateEnemies();
	}

    private int numEnemies()
    {
        return GameObject.FindGameObjectsWithTag("monster").Length;

    }

    public void GenerateEnemies()
    {
        StartCoroutine("generator");
    }

    IEnumerator generator()
    {
        int conta = points.Count-1;

        while (conta > 0)
        {
            GameObject GO= Instantiate(enemy, points[Random.Range(0, points.Count - 1)].transform.position, new Quaternion());
            GO.transform.parent = points[conta].transform;
            GO.tag = "monster";

            yield return new WaitForSeconds(Random.Range(.5f,3f));

            conta--;
        }

    }
}
