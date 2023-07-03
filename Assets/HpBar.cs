using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public GameObject StatusScr;
    public GameObject SL;
    Slider _slider;
    void Start()
    {

        //get slider
        _slider = SL.GetComponent<Slider>();
    }

    int _hp = 0;
    void Update()
    {
        //get script
        StatusMore statusmore = StatusScr.GetComponent<StatusMore>();
        _hp = statusmore.currentHP;

        // HPゲージに値を設定
        _slider.value = _hp;
    }
}