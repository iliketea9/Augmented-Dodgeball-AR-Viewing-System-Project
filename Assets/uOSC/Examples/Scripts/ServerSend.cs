using UnityEngine;
using UnityEngine.UI;
using System;

namespace uOSC
{

    [RequireComponent(typeof(uOscServer))]
    public class ServerSend : MonoBehaviour
    {
        public GameObject LogText;
        int now;

        void Start()
        {
            var server = GetComponent<uOscServer>();
            server.onDataReceived.AddListener(OnDataReceived);

        }

        void Update()
        {
            now = DateTime.Now.Hour * 60 * 60 * 1000 + DateTime.Now.Minute * 60 * 1000 +
DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
        }

        void OnDataReceived(Message message)
        {
            LogText.SetActive(true);

            // address
            var msg = message.address + ": ";

            // timestamp
            // msg += "(" + message.timestamp.ToLocalTime() + ") ";

            //msg += "(" + now + ") ";

            // values
            foreach (var value in message.values)
            {
                msg += value.GetString() + " ";
            }

            Debug.Log(msg);

            var client = GetComponent<uOscClient>();
            client.Send("/uOSC/ReSend", msg);

        }

    /*    void ReSend()
        {
            var client = GetComponent<uOscClient>();

            client.Send("/uOSC/send", now, "sendtime");

        }
        */
    }


}