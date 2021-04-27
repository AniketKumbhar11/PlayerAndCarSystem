using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMsg : MonoBehaviour
{
    public GameObject MsgShowText;
    public GameObject Parent;

    public GameObject obj;
    public static ShowMsg showmsg;
    private void Awake()
    {
        showmsg = this;
    }
    public void Show(string msg)
    {
        obj = Instantiate(MsgShowText);
        obj.transform.SetParent(Parent.transform);
        obj.GetComponent<Text>().text = msg;


    }
    public void DestroyMsg()
    {
        Destroy(obj);
    }


}
