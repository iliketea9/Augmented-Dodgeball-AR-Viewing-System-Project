using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class AirTapRegister : MonoBehaviour, IInputClickHandler
{
    //public Camera HololensCamara;
    public GameObject FieldSpace;
    Vector3 Field;
    public float MarkerToCam;
    public GameObject OKmarker;
    Vector3 welcome;
    public GameObject Del;

    void Start()
    {
        //AirTapを検出したとき、OnInputClickedが呼ばれる。
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    }

    void Update()
    {


    }

    //AirTapを検出したとき呼ばれるメソッド
    public void OnInputClicked(InputClickedEventData eventData)
    {
        //AirTap検出時の処理を記述

      ////////  Field = this.transform.position;
       // Field.z = Field.z + MarkerToCam;
    //    Field.x = Field.x - 0.3f;
   //     FieldSpace.transform.position = Field;

        Del.SetActive(false);
        FieldSpace.SetActive(true);

        welcome = this.transform.position;
       // welcome.y = welcome.y + 0.01f;
       // welcome.x = welcome.x - 0.01f;
        OKmarker.transform.position = welcome;

        OKmarker.SetActive(true);
        
    }


}