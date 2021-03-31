using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedScript : MonoBehaviour
{
    float range = 100f;
    bool canAttack = false;
    float timeLeft = 3;
    bool idle = false;

    // Start is called before the first frame update
    private GameObject CheckForEnemies(Vector3 center, float radius) {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Enemy")) {
                canAttack = true;
            }
        }
        return hitColliders[0].gameObject;
    }
    private void Attack(GameObject enemy) {
        timeLeft-=Time.deltaTime;
        if (timeLeft<0&&canAttack) {
            timeLeft = 3;
            canAttack = false;
            Debug.Log("deneme");
            //enemyden can düş
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        Attack(CheckForEnemies(this.transform.position, range));
    }
}
