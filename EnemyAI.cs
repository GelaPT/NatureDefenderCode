using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private GameObject lostCanvas;

    public NavMeshAgent agent;

    private Transform target;

    public LayerMask whatIsTower;

    public int health;

    private Animator animator;

    //attacking
    public float attackDelay;
    private bool hasAttacked;

    //states
    public float attackRange;
    private bool inAttackRange;

    private int attacks = 0;

    private void Awake()
    {
        target = GameObject.Find("Tower").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Start() {
        lostCanvas = UIManager.Instance.lostCanvas;
    }

    private void Update()
    {
        inAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsTower);

        if (inAttackRange) Attack();
        else Chase();
    }

    private void Chase()
    {
        agent.SetDestination(target.position);
    }
    private void Attack()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(target);

        if (!hasAttacked)
        {
            hasAttacked = true;
            //script de atacar aqui

            attacks++;

            animator.SetBool("attack", hasAttacked);
            Invoke(nameof(ResetAttack), attackDelay);

            if(attacks > 4) {
                if(lostCanvas != null) lostCanvas.SetActive(true);
                Invoke(nameof(Quit), 3f);
            }
        }
    }

    private void ResetAttack()
    {
        hasAttacked = false;
        animator.SetBool("attack", hasAttacked);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Destroy(gameObject);
    }

    //adicional
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void Quit() {
        Application.Quit();
    }
}
