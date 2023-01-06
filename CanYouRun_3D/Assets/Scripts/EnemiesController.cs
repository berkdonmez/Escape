using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesController : MonoBehaviour
{
    public GameObject AttackTarget;
    NavMeshAgent navmeshAgent;
    bool attackIsStart;

    void Start()
    {
        navmeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (attackIsStart == true)
        {
            navmeshAgent.SetDestination(AttackTarget.transform.position);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AICharacter"))
        {
            Vector3 newPosition = new Vector3(transform.position.x, 1, transform.position.z);

            GameManager.Instance.deadParticleSystem(gameObject.transform, false, true);
            gameObject.SetActive(false);
        }
    }

    public void OnAttack()
    {
        GetComponent<Animator>().SetBool("Attack", true);
        attackIsStart = true;
    }
}
