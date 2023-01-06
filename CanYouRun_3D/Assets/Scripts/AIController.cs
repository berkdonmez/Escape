using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    GameObject target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>().FinishPoint;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        agent.SetDestination(target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BarbedBox"))
        {
            Vector3 newPosition = new Vector3(transform.position.x, 2, transform.position.z);

            GameManager.Instance.deadParticleSystem(gameObject.transform);
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Saw"))
        {
            Vector3 newPosition = new Vector3(transform.position.x, 1, transform.position.z);

            GameManager.Instance.deadParticleSystem(gameObject.transform);
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("PropellerBarbeds"))
        {
            Vector3 newPosition = new Vector3(transform.position.x, 1, transform.position.z);

            GameManager.Instance.deadParticleSystem(gameObject.transform);
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Hammer"))
        {
            Vector3 newPosition = new Vector3(transform.position.x, 1, transform.position.z);

            GameManager.Instance.deadParticleSystem(gameObject.transform, true);
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Vector3 newPosition = new Vector3(transform.position.x, 1, transform.position.z);

            GameManager.Instance.deadParticleSystem(gameObject.transform,false,false);
            gameObject.SetActive(false);
        }

    }
}
