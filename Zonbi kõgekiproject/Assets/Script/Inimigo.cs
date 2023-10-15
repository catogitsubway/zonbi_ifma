using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class Inimigo : MonoBehaviour
{

    public float maxHealth;
    public float currentHealth;

    public Animator animInimigo;
    private NavMeshAgent navMesh;
    private GameObject player;
    public float velocidadeInimigo;
    private GameObject maoInimigo;


    void Awake()
    {
        
        currentHealth = maxHealth;

        animInimigo = GetComponent<Animator>();
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMesh.speed = velocidadeInimigo;

        player = GameObject.FindWithTag("Player");
        maoInimigo = GameObject.FindWithTag("maoInimigo");
        maoInimigo.SetActive(false);
    }

    void Update()
    {

        navMesh.destination = player.transform.position;
        animInimigo.SetBool("run", true);
        
        if (Vector3.Distance(transform.position, player.transform.position) < 1.5f)
        {
            navMesh.speed = 1;
            maoInimigo.SetActive(true);
            animInimigo.SetBool("atack", true);
            StartCoroutine("ataque");

        }
       
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if(currentHealth <= 0)
        {
            animInimigo.SetBool("death", true);
            navMesh.speed = 0;
        }
    }


    IEnumerator ataque()
    {
        yield return new WaitForSeconds(0.2f);
        animInimigo.SetBool("atack", false);
        yield return new WaitForSeconds(2.8f);
        maoInimigo.SetActive(false);
        navMesh.speed = velocidadeInimigo;
    }
}
