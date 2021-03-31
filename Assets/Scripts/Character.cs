using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
public class Character : MonoBehaviour {
    static int characterID=0;
    public int id;
    private AIDestinationSetter aiDestinationSetter;
    Transform pos_;
    GameObject positionObject;
    bool destinationSet = false;
    bool destroyedPositionObject = false;//destroy the position object given by A*
    private void Start() {
        pos_=this.transform;
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
        characterID++;
        id=characterID;
    }
    private void Update() {

        destroyDestinationObject();
    }
    public void SetDestination(GameObject go){
        positionObject = go;
        Transform pos = positionObject.transform;
        pos_=pos;
        aiDestinationSetter.target=pos_;
        destinationSet = true;
        destroyedPositionObject = false;
    }
    public void destroyDestinationObject()
    {
        //if the given position object is set, and hasnt been destroyed
        //yet, and character has reached the target
        if (!destroyedPositionObject&&destinationSet&&Vector3.Distance(positionObject.transform.position,transform.position)>Vector3.kEpsilon) {
            Destroy(positionObject);
            destroyedPositionObject = true;
        }
    }
    public int GetId(){
        return id;
    }
}