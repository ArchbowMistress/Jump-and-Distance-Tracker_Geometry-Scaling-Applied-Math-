using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackStab : MonoBehaviour
{
    public Transform enemy;
    public float backstabDistance = 2.0f;
    private bool hasBackstabbed = false;
    public Text backstabText;

    // Update is called once per frame
    void Update()
    {
        if (enemy == null || hasBackstabbed) return;

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 toOther = Vector3.Normalize(transform.position - enemy.position);
        float distance = Vector3.Distance(transform.position, enemy.position);

        //Debug.Log(Vector3.Dot(forward, toOther));
        if (Vector3.Dot(forward, toOther) < -0.5f && distance < backstabDistance)
        {
            FrenchSpecial();
            BackstabText();
        }

    }

    public void FrenchSpecial()
    {
        // Vector3 directionToEnemy = enemy.position - transform.position;
        // directionToEnemy.y = 0;

        if (hasBackstabbed) return;
        hasBackstabbed = true;

        Debug.Log("CRITICAL HIT!!!");
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            enemyMovement.Die();
        }
    }

    public string BackstabText()
    {

        backstabText.text = "CRITICAL HIT!!!";
        return backstabText.text;
        
    }
    
}
