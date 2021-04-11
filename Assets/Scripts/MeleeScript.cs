using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScript : MonoBehaviour
{
    bool canAttack = false;
    float timeLeft = 1;
    float range = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        Attack(CheckForEnemies(this.transform.position,range));   
    }
    private GameObject CheckForEnemies(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Enemy")&&!canAttack)
            {
                canAttack = true;
                Debug.Log("Enemy");
            }
        }
        //kritik
        return hitColliders[1].gameObject;// burda var bi nane
    }
    public void Attack(GameObject target) {
        Debug.Log("attack giriş");
        if (canAttack)
        {

            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                //damage


                canAttack = false;
                timeLeft = 1;
                target.GetComponent<Enemy>().InflictDamage(5);


            }
        }
    }
}
