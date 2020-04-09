using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSONOjbectMap;

public class TestTextReaders : MonoBehaviour
{

    GhostManager manager;

    public GameObject PacMan;
    
    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {


        //Console.GameConsoleWrite("TestTextReaders: Start Called");

        manager = new GhostManager(PacMan);

        //simple test
        


    }

    // Update is called once per frame
    void Update()
    {
        manager.Update();
        if(Input.GetKeyUp(KeyCode.A))
        {
            manager.State = GhostManager.GhostManagerState.StartAuto;
        }
    }

    
}
