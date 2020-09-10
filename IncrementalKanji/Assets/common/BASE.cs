using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BASE : MonoBehaviour
{
    public static Main main;
    public void StartBASE()
    {
        main = UsefulMethod.GetMain();
    }
    /*
    public static Main GetMain()
    {
        GameObject mainCtrl = GameObject.FindGameObjectWithTag("mainCtrl");
        return mainCtrl.GetComponent<Main>();
    }
    */
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}