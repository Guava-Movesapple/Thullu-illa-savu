using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour

{

    public GameObject[] levels;
    public float end = 3;
    public float timer =0;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(levels[0],new Vector3(0,0,0),transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < end)
        {
            timer += Time.deltaTime;
        }
        else 
        {
            Instantiate(levels[Random.Range(0,2)],transform.position,transform.rotation);
            timer=0;
        }
    }
}
