using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleImage : MonoBehaviour
{
    public GameObject StatusScr;
    public GameObject attacker;
    public GameObject defender;
    public GameObject balanced;
    public string manual;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //get script
        Status status = StatusScr.GetComponent<Status>();

        if (manual/*status.roletype*/ == "attacker")
        {
            attacker.SetActive(true);
            defender.SetActive(false);
            balanced.SetActive(false);
        }
        else if(manual/*status.roletype*/ == "defender")
        {
            attacker.SetActive(false);
            defender.SetActive(true);
            balanced.SetActive(false);
        }
        else if(manual/*status.roletype*/ == "balanced")
        {
            attacker.SetActive(false);
            defender.SetActive(false);
            balanced.SetActive(true);
        }

	}
}
