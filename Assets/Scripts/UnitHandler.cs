using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class UnitHandler : MonoBehaviour {
    selected_dictionary selected_table;

    List<Unit> Units = new List<Unit>();
    private void Start() {
        selected_table=GetComponent<selected_dictionary>();//get dictionary of selected items
        
    }
    public void CrateAndMoveUnit(){
        
    }
    public void AddUnit(Unit u){
        Units.Add(u);
    }
    public void RemoveUnit(Unit u){
        Units.Remove(u);
    }

}