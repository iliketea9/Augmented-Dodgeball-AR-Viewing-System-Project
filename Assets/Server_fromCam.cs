using UnityEngine;
using UnityEngine.UI;
using System;

namespace uOSC
{

    [RequireComponent(typeof(uOscServer))]
    public class Server_fromCam : MonoBehaviour
    {
       // public GameObject LogText;
        int now;
        float x = 1;
        float y = 1 ;
        float z = 1;


        void Start()
        {
            var server = GetComponent<uOscServer>();
            server.onDataReceived.AddListener(OnDataReceived);

        }

        void Update()
        {
            now = DateTime.Now.Hour * 60 * 60 * 1000 + DateTime.Now.Minute * 60 * 1000 +
DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;

            //Debug.Log("x: " + x + " y: " + y + " z: " + z);
        }

        void OnDataReceived(Message message)
        {
            //    LogText.SetActive(true);

            // address
            //var msg = message.address + ": ";

            // timestamp
            // msg += "(" + message.timestamp.ToLocalTime() + ") ";

            //msg += "(" + now + ") ";

            // values
            //foreach (var value in message.values)
            //{
            //    msg += value.GetString() + " ";
            //}

            /*   if (message.address == "/uOSC/pos/x")
               {
                   x = (float)message.values[0];
               }
               else if (message.address == "/uOSC/pos/y")
               {
                   y = (float)message.values[0];
               }
               else if (message.address == "/uOSC/pos/z")
               {
                   z = (float)message.values[0];
               } */
            // Debug.Log("recieved" + now);

            x = (float)message.values[0];
            y = (float)message.values[1];
            z = (float)message.values[2];

            Vector3 thispos = this.transform.position;
            thispos.x = x;
            thispos.y = y;
            thispos.z = z;
            this.transform.position = thispos;
        }

        public float GetX()
            {
                return x;
            }

        public float GetY()
        {
            return y;
        }
        public float GetZ()
        {
            return z;
        }
    }


}