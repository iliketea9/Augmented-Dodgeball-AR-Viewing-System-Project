using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 trans = this.transform.position;

        if (Input.GetKeyDown(KeyCode.K))
        {

            trans.x -= 0.3f;
            this.transform.position = trans;
        }
    }
}
