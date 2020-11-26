using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Unit : MonoBehaviour {
    public static int unitCount=0;
    private int unitId;
    List<Character> characters = new List<Character>();
    public Unit(){
        unitCount++;
        unitId=unitCount;
    }
    public void AddCharacter(Character c){
        characters.Add(c);
    }
    public void RemoveCharacter(Character c){
        characters.Remove(c);
    }
    public void ClearUnit(){
        characters.Clear();
    }
    private void Start() {
        
        
    }
    private void Update() {
       foreach (Character c in characters)
       {
           c.Move();
       }
    }


}