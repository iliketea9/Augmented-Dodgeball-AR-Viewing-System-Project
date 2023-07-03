using UnityEngine;

namespace uOSC
{

    [RequireComponent(typeof(uOscClient))]
    public class ClientSendCoord : MonoBehaviour
    {
        void Update()
        {
            var client = GetComponent<uOscClient>();

            var bundle1 = new Bundle(Timestamp.Immediate);
            bundle1.Add(new Message("/uOSC/bundle1/message1", this.transform.position.x, this.transform.position.y, this.transform.position.z));

            client.Send(bundle1);
        }
    }
}