using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HpBarCtrl : MonoBehaviour
{
    public GameObject StatusScr;
    public GameObject SL;
    Slider _slider;
    public int _manhp;
    void Start()
    {

        //get slider
        _slider = SL.GetComponent<Slider>();
    }

    int _hp = 0;
    void Update()
    {
        //get script
        Status status = StatusScr.GetComponent<Status>();
        _hp = status.currentHP;

        // HPゲージに値を設定
     //   _slider.value = _hp;
        _slider.value = _manhp;
    }
}