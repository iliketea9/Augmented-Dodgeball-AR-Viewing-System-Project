using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubeCommand : MonoBehaviour {

    public GameObject tmp;
    public GameObject PointObj;
    public Material selected;
    Vector3 postmp;
    Vector3 rottmp;

    public void OnSelect()
    {
        Debug.Log("OnSelect");

        var material = GetComponent<Renderer>().material;
        GetComponent<Renderer>().material = selected;
        PointObj.transform.position = postmp;
        PointObj.transform.Rotate(rottmp);

    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        postmp = tmp.transform.position;
    //    rottmp = transform.rotation.eulerAngles;

     //   if (Input.GetKey(KeyCode.A))
       // {
         //   Debug.Log("Crick");

           // var material = GetComponent<Renderer>().material;
          //  GetComponent<Renderer>().material = selected;
            PointObj.transform.position = postmp;
         //   PointObj.transform.rotation = transform.localEulerAngles;

        //}


    }
}
