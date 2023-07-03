using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time5sFalse : MonoBehaviour {

    public GameObject kore;
    float time;

	// Use this for initialization
	void Start () {
   //     Invoke("close", 5);
    }
	
	// Update is called once per frame
	void Update () {
        time = time + Time.deltaTime;
        if (time >= 5.0f)
        {

            time = 0;
            kore.SetActive(false);


        }
    }
    /*
    void close ()
    {
            kore.SetActive(false);
        }
    }
    */
}
