using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

namespace uOSC
{

    [RequireComponent(typeof(uOscServer))]
    public class ServerTest : MonoBehaviour
    {

        public GameObject LogText;
        int now;
        string writelog;
        float timeleft;

        void Start()
        {
            var server = GetComponent<uOscServer>();
            server.onDataReceived.AddListener(OnDataReceived);
        }
        void Update()
        {
            now = DateTime.Now.Hour * 60 * 60 * 1000 + DateTime.Now.Minute * 60 * 1000 +
DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;

        /*    timeleft += Time.deltaTime;
            if (timeleft >= 5.0f)
            {
                timeleft = 0.0f;
                textSave(writelog);
            } */
        }

        void OnDataReceived(Message message)
        {
            // address
            var msg = message.address + ": ";

            // timestamp            
            // msg += "(" + message.timestamp.ToLocalTime() + ") ";

            // values
            foreach (var value in message.values)
            {
                msg += value.GetString() + " ";
            }

            msg += "," + now;

            //   Debug.Log(DateTime.Now.Hour +"," +DateTime.Now.Minute +","+ DateTime.Now.Second +","+ DateTime.Now.Millisecond);
            Debug.Log(msg);

         /*   writelog = writelog + msg + "\n"; */
            //          LogText.SetActive(true);
            //   mssg = ToString(msg);
          //  textSave(msg);

        }

     /*   public void textSave(string txt)
        {
            StreamWriter sw = new StreamWriter("../Augd-Log/LogData009.txt", true); //true=追記 false=上書き
            sw.WriteLine(txt);
            sw.Flush();
            sw.Close();

        }
        */
    }

}