using UnityEngine;
using System;
using System.IO;

namespace uOSC
{



    [RequireComponent(typeof(uOscClient))]
    public class ClientSend: MonoBehaviour
    {
        int now;
        string sendlog;
        float timeleft;

        void Update()
        {
            var client = GetComponent<uOscClient>();

            now = DateTime.Now.Hour * 60 * 60 * 1000 + DateTime.Now.Minute * 60 * 1000 +
    DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;

            var sendmsg = "sendtime,recievetime," + now;

//            client.Send("/uOSC/send", "sendtime,recievetime,",now);
            client.Send("/uOSC/send", sendmsg);
      /*      sendlog = sendlog + sendmsg + "\n";

            timeleft += Time.deltaTime;
            if (timeleft >= 5.0f)
            {
                timeleft = 0.0f;
                textSave(sendlog);
            }*/

            //            client.Send("/uOSC/test", 10, "hoge", "hogehoge", 1.234f, 123f);
        }


  /*      public void textSave(string txt)
        {
            StreamWriter sw = new StreamWriter("../Augd-Log/SendData009.txt", true); //true=追記 false=上書き
            sw.WriteLine(txt);
            sw.Flush();
            sw.Close();

        } */

    }

}