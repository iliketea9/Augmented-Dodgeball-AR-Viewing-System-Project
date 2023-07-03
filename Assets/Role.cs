using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role : MonoBehaviour
{
    public GameObject StatusScr;
    public GameObject attacker;
    public GameObject defender;
    public GameObject balanced;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //get script
        StatusMore statusmore = StatusScr.GetComponent<StatusMore>();

        if (statusmore.roletype == "attacker")
        {
            attacker.SetActive(true);
            defender.SetActive(false);
            balanced.SetActive(false);
        }
        else if (statusmore.roletype == "defender")
        {
            attacker.SetActive(false);
            defender.SetActive(true);
            balanced.SetActive(false);
        }
        else if (statusmore.roletype == "balanced")
        {
            attacker.SetActive(false);
            defender.SetActive(false);
            balanced.SetActive(true);
        }

    }
}
