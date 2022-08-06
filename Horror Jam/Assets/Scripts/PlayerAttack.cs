using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] public int attackDamage = 10;
    [SerializeField] private float attackSpeed = 1f;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float canAttack;
    public LayerMask enemyLayers;
    void Start()
    {
        //Set the tag of this GameObject to Player
    }


    void Update()
    {
        if (attackSpeed <= canAttack)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                canAttack = 0f;
            }

        }
        else
        {
            canAttack += Time.deltaTime;
        }
    }

    void Attack()
    {
        Collider2D[] hitenimies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitenimies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
