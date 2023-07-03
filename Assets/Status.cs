using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using HoloToolkit.Unity.InputModule;
using System;

[System.Serializable]
public class StatusJsonData
{
    public string name;
    public int currenthp;
    public int maxhp;
    public string role;
    public float pos_x;
    public float pos_y;
    public float pos_z;
}

public class Status : MonoBehaviour //, IInputClickHandler
{

    public Text ResultText_;    //text_GameObject to desplay result text
    public Text HP;
    public Text Role;
    private string hp;
    public string id;   //Player id input
    public int currentHP;
    public string roletype;
    private float x;
    private float y;
    private float z;


  // private string ServerAddress = "http://www.nojilab.org/ADodgeball_status_get.php";  //server URL of "selecttest.php" (test on vps)
  // private string ServerAddress_pos = "http://www.nojilab.org/ADodgeball_position_input.php";  //server URL of "selecttest.php" (test on vps)

    private string ServerAddress = "http://www.teres.club.uec.ac.jp/selecttest.php";  //server URL of "selecttest.php" (test on vps)//
    private string ServerAddress_pos = "http://www.teres.club.uec.ac.jp/posinput.php";  //server URL of "selecttest.php" (test on vps)


  // private string ServerAddress = "http://dodgeball.sakura.ne.jp/ADodgeball_status_get.php";  //server URL of "selecttest.php" (test on vps)
  // private string ServerAddress_pos = "http://dodgeball.sakura.ne.jp/ADodgeball_position_input.php";  //server URL of "selecttest.php" (test on vps)

   //     private string ServerAddress = "https://alevam.me/selecttest.php";  //server URL of "selecttest.php" (test on vps)//

    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    System.Diagnostics.Stopwatch sw2 = new System.Diagnostics.Stopwatch();




    public void OnSelect()
    {
        StartCoroutine("Access");   // Start Access Corutine 
        StartCoroutine("SendPos");
    }






    private IEnumerator Access()
    {
        while (true)
        {
            // 1秒毎にループします
            yield return new WaitForSeconds(1f);

            Dictionary<string, string> dic = new Dictionary<string, string>();

            dic.Add("id", id);  // Player id
                                //If there are a plurality of data to be transmitted, it can be added in this way, : dic.Add("hoge", value)

            StartCoroutine(Post(ServerAddress, dic));  // POST
        }
        //yield return 0;
    }

    private IEnumerator SendPos()
    {
        while (true)
        {
            // 1秒毎にループします
            yield return new WaitForSeconds(1f);

            Dictionary<string, string> input = new Dictionary<string, string>();

            input.Add("id", id);  // Player id
            input.Add("pos_x", this.transform.position.x.ToString());
            input.Add("pos_y", this.transform.position.y.ToString());
            input.Add("pos_z", this.transform.position.z.ToString());

            //Debug.Log("Current Position : " + x.ToString() +";"+ y.ToString()+";"+z.ToString());
            
                                //If there are a plurality of data to be transmitted, it can be added in this way, : dic.Add("hoge", value)

            StartCoroutine(PostPos(ServerAddress_pos, input));  // POST
        }
        //yield return 0;
    }
    





    private IEnumerator Post(string url, Dictionary<string, string> post)
    {
        
        WWWForm form = new WWWForm();
        sw.Reset();
        sw.Start();
        foreach (KeyValuePair<string, string> post_arg in post)
        {
            form.AddField(post_arg.Key, post_arg.Value);
        }
        WWW www = new WWW(url, form);


        yield return StartCoroutine(CheckTimeOut(www, 1f)); //TimeOutSecond = 1s;

        if (www.error != null)
        {
            Debug.Log("HttpPost NG: " + www.error);
            //if can't connect to server

        }
        else if (www.isDone)
        {
            //result www.text into ResultText_
            StatusJsonData data = JsonUtility.FromJson<StatusJsonData>(www.text);

            Debug.Log(
                string.Format("{0} : {1} : {2} : {3} : {4} : {5} : {6}",
                    data.name, data.currenthp, data.maxhp, data.role, data.pos_x, data.pos_y, data.pos_z)
            );
            
            ResultText_.GetComponent<Text>().text = data.name;
            HP.GetComponent<Text>().text = data.currenthp + "/" + data.maxhp;
            currentHP = data.currenthp;
            Role.GetComponent<Text>().text = data.role;
            roletype = data.role;
            // DBから座標を取得する時
            x = data.pos_x;
            z = data.pos_z;

            sw.Stop();
            Debug.Log("データ読み取り経過時間:" + sw.ElapsedMilliseconds + "ms");

            // Debug.Log(www.text);
        }

    }




    private IEnumerator PostPos(string url, Dictionary<string, string> post)
    {
        WWWForm form = new WWWForm();
        sw2.Reset();
        sw2.Start();
        foreach (KeyValuePair<string, string> post_arg in post)
        {
            form.AddField(post_arg.Key, post_arg.Value);
        }
        WWW www = new WWW(url, form);


        yield return StartCoroutine(CheckTimeOut(www, 1f)); //TimeOutSecond = 1s;

        if (www.error != null)
        {
            Debug.Log("HttpPost NG: " + www.error);
            //if can't connect to server

        }
        else if (www.isDone)
        {
            //result www.text into ResultText_
            //            StatusJsonData data = JsonUtility.FromJson<StatusJsonData>(www.text);
            sw2.Stop();

            Debug.Log("座標送信経過時間:" + sw2.ElapsedMilliseconds + "ms");
            //Debug.Log(www.text);
        }

    }
    

    private IEnumerator CheckTimeOut(WWW www, float timeout)
    {
        float requestTime = Time.time;

        while (!www.isDone)
        {
            if (Time.time - requestTime < timeout)
                yield return null;
            else
            {
                Debug.Log("TimeOut");  //Timeout
                //タイムアウト処理
                //
                //
                break;
            }
        }
        yield return null;
    }

    //public void OnInputClicked(InputEventData eventData)
    //{
        
    //}

 //   public void OnInputClicked(InputClickedEventData eventData)
  //  {
  //      OnSelect();
  //  }

    //if MouseClick, run function 
    
      void Start()
     {
    //     if (Input.GetMouseButtonDown(0))
      //   {
             OnSelect();
        // }
     }

    private void Update()
    {
        /*
        
        Vector3 thispos = this.transform.position;
          
        thispos.x = x;
        // HPバー表示位置の高さ調節、基準点を置いたテーブルからの高さ  -  Adjusting the height of the HP bar display position and the height from the table on which the reference point is placed.

        thispos.y = thispos.y + 0.25f ;
        thispos.z = z;

        this.transform.position = thispos;

        */
    }

    public int GetCurrentHP()
    {
        return currentHP;
    }
}