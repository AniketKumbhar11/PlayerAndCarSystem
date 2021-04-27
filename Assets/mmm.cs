using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mmm : MonoBehaviour
{
    public bool tig,temp;


    private void Update()
    {
        if (tig&&Input.GetKeyDown(KeyCode.E))
        {
            if (!ScriptHolder.ScriptHilderObj.Enter)
            {

                this.transform.parent.GetComponent<SimpleCarController>().CarInput = true;
                Destroy(PLayerScript.ObjPlayer.gameObject);

                ShowMsg.showmsg.DestroyMsg();

                ScriptHolder.ScriptHilderObj.Enter = true;
            }
            else
            {
                Instantiate(ScriptHolder.ScriptHilderObj.Player, this.gameObject.transform.GetChild(0).transform.position,Quaternion.identity);
                ScriptHolder.ScriptHilderObj.Enter = false;
               this.transform.parent.GetComponent<SimpleCarController>().CarInput = false;
                this.tig = false;

            }
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Player"))
        {
           this.tig = true;
            ShowMsg.showmsg.Show("Press E to Enter Car");

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "Player"))
        {
            ShowMsg.showmsg.DestroyMsg();
           this.tig = false;
        }
    }
}
