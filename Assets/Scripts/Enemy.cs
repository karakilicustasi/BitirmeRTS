using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    int kill;
    int numberOfChilds;
    public MeshRenderer rd;
    public int type; //0-infantry 1 - ranged 2 - cavalry

    List<Character> characters = new List<Character>();



    public void DestroyUnit()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Flasher()
    {
        for (int i = 0; i < 5; i++)
        {
            rd.material.color = Color.red;
            yield return new WaitForSeconds(.1f);
            rd.material.color = Color.grey;
            yield return new WaitForSeconds(.1f);
        }
    }



    void Start()
    {
        health = 100;
        kill = health - 25;
        numberOfChilds = 0;
        fillCharacterList();
    
    }

    // Update is called once per frame
    void Update()
    {
        Destroy();
        DestroyUnit();
        Debug.Log(health + " - EnemyHealth");
    }
    public void InflictDamage(int damage) {
        health -= damage;
        StartCoroutine(Flasher()); 
    
    }

    public void Destroy()
    {
        int unitCountTemp = numberOfChilds;
        if (health <= kill)
        {
            Destroy(characters[unitCountTemp - 1].gameObject);
            characters.RemoveAt(unitCountTemp - 1);
            unitCountTemp--;
            kill = kill - 25;
        }
        numberOfChilds = unitCountTemp;

    }
    private void fillCharacterList()
    {

        foreach (Transform child in this.transform)
        {
            Character c = child.gameObject.GetComponent<Character>();
            characters.Add(c);
            numberOfChilds++;
        }
    }
}
