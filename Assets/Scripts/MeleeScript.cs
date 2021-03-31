using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScript : MonoBehaviour
{
    bool canAttack = false;
    float timeLeft = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        Attack();   
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) {
            canAttack = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {

    }
    public void Attack() {
        if (canAttack)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                //damage
                Debug.Log("vur");
                canAttack = false;
                timeLeft = 1;

            }
        }
    }
}
