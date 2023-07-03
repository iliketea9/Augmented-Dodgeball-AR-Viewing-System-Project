using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class AirTapMoreInfo : MonoBehaviour, IInputClickHandler
{
    //public Camera HololensCamara;
    public GameObject MoreInfo;

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

        MoreInfo.SetActive(true);

    }


}