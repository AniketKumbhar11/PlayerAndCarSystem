using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptHolder : MonoBehaviour
{
    public static ScriptHolder ScriptHilderObj;
    public bool Enter;
    public GameObject Player;

    private void Awake()
    {
        ScriptHilderObj = this;
     //   Instantiate(Player);


    }

    void Start()
    {
        
    }

    void Update()
    {



    }
}
