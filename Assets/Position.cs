using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour {

    public GameObject HoloCamera;
    Vector3 HoloPosi;

	// Use this for initialization
	void Start () {

        GetHoloPosi();
     //   HoloPosi = HoloCamera.transform.position;
        // HoloPosi.z += 0.8f;
       // this.transform.position = HoloPosi;
        //Debug.Log(HoloPosi.x + HoloPosi.y + HoloPosi.z);
		
	}
	
	// Update is called once per frame
	void Update () {
     //   HoloPosi = HoloCamera.transform.position;

    }
    void GetHoloPosi()
    {
        HoloPosi = HoloCamera.transform.position;
        // HoloPosi.z += 0.8f;
        this.transform.position = HoloPosi;
    }
}

