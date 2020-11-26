using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Character : MonoBehaviour {
    public LayerMask canBeClickedOn;
    private UnityEngine.AI.NavMeshAgent agent;
    static int characterID=0;
    //public bool moveable=false;
    int id;
    private void Start() {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        characterID++;
        id=characterID;
    }
    private void Update() {
      //  Move();
    }
    public void Move(){
        if(Input.GetMouseButtonDown(1)/*&&moveable*/){

            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Debug.Log("clicked");
            if(Physics.Raycast(myRay, out hitInfo,Mathf.Infinity,canBeClickedOn)){
                agent.SetDestination(hitInfo.point);
                Debug.Log(hitInfo.point);
            }

        }
    }
    public int GetId(){
        return id;
    }
}