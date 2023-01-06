using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Berk;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //public GameObject bornPoint;
    public GameObject FinishPoint;
    public List<GameObject> ObjectPooling;
    public List<GameObject> BornParticleSystems;
    public List<GameObject> DeadParticleSystems;
    public List<GameObject> Enemies;
    public int HowManyEnemiesAreThere;
    public static int counterOfCharacters = 1;

    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        EnemyCreate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemyCreate()
    {
        for (int i = 0; i < HowManyEnemiesAreThere; i++)
        {
            Enemies[i].SetActive(true);
        }
    }

    public void EnemiesTrigger()
    {
        foreach (var item in Enemies)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<EnemiesController>().OnAttack();
            }
        }
    }


    public void WarSituation()
    {
        if (counterOfCharacters == 1 || HowManyEnemiesAreThere == 0)
        {
            foreach (var item in Enemies)
            {
                if (item.activeInHierarchy)
                {
                    item.GetComponent<Animator>().SetBool("Attack", false);
                }
            }

            foreach (var item in ObjectPooling)
            {
                if (item.activeInHierarchy)
                {
                    item.GetComponent<Animator>().SetBool("Attack", false);
                }
            }

            if (counterOfCharacters < HowManyEnemiesAreThere || counterOfCharacters == HowManyEnemiesAreThere)
            {
                Debug.Log("Game Over");
            }
            else
            {
                Debug.Log("Win");
            }
        }
    }

    public void CharacterManager(string process, int processName, Transform position)
    {
        switch (process)
        {
            case "Multiplication":
                Library.Multiplication(processName, ObjectPooling, position, BornParticleSystems);
                break;


            case "Addication":
                Library.Addication(processName, ObjectPooling, position, BornParticleSystems);
                break;


            case "Extraction":
                Library.Extraction(processName, ObjectPooling, DeadParticleSystems);
                break;

            case "Division":
                Library.Division(processName, ObjectPooling, DeadParticleSystems);
                break;
        }
    }

    public void deadParticleSystem(Transform position, bool Hammer = false, bool situation = false)
    {
        foreach (var item in DeadParticleSystems)
        {
            if (!item.activeInHierarchy)
            {
                item.gameObject.SetActive(true);
                item.transform.position = position.transform.position;
                item.GetComponent<ParticleSystem>().Play();
                if (!situation)
                {
                    counterOfCharacters--;
                }

                else
                {
                    HowManyEnemiesAreThere--;
                }
                break;

            }
        }
        WarSituation();
    }

    public void bornParticleSystem(Transform position)
    {
        foreach (var item in DeadParticleSystems)
        {
            if (!item.activeInHierarchy)
            {
                item.gameObject.SetActive(true);
                item.transform.position = position.transform.position;
                item.GetComponent<ParticleSystem>().Play();
                //counterOfCharacters--;
                break;

            }
        }
    }


}
