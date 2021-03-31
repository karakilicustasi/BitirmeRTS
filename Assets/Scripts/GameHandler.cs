using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    UnitHandler unitHandler;
    // Start is called before the first frame update
    void Start()
    {
        unitHandler = GetComponent<UnitHandler>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if(Input.GetMouseButtonUp(0)){
                unitHandler.CreateUnit(9,new Vector3(0,0,0));
            }
        }
    }
}
