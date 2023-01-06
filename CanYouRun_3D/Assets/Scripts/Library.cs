using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Berk
{
    public class Library : MonoBehaviour
    {
        public static void Multiplication(int processNumber, List<GameObject> objectPooling, Transform position, List<GameObject> bornParticleEffects)
        {

            int loopNumber = (GameManager.counterOfCharacters * processNumber) - GameManager.counterOfCharacters;
            int number1 = 0;
            foreach (var item in objectPooling)
            {
                if (number1 < loopNumber)
                {
                    if (!item.activeInHierarchy)
                    {

                        foreach (var item2 in bornParticleEffects)
                        {
                            if (!item2.activeInHierarchy)
                            {
                                item2.SetActive(true);
                                item2.transform.position = position.transform.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                break;
                            }

                        }
                        item.transform.position = position.transform.position;
                        item.gameObject.SetActive(true);
                        number1++;

                    }
                }
                else
                {
                    number1 = 0;
                    break;
                }

            }
            GameManager.counterOfCharacters *= processNumber;

        }

        public static void Addication(int processNumber, List<GameObject> objectPooling, Transform position, List<GameObject> bornParticleEffects)
        {

            int number2 = 0;
            foreach (var item in objectPooling)
            {
                if (number2 < processNumber)
                {
                    if (!item.activeInHierarchy)
                    {

                        foreach (var item2 in bornParticleEffects)
                        {
                            if (!item2.activeInHierarchy)
                            {
                                item2.SetActive(true);
                                item2.transform.position = position.transform.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                break;
                            }

                        }
                        item.transform.position = position.transform.position;
                        item.gameObject.SetActive(true);
                        number2++;

                    }
                }
                else
                {
                    number2 = 0;
                    break;
                }

            }
            GameManager.counterOfCharacters += processNumber;

        }

        public static void Extraction(int processNumber, List<GameObject> objectPooling, List<GameObject> deadParticleEffects)
        {

            if (GameManager.counterOfCharacters < processNumber)
            {
                foreach (var item in objectPooling)
                {

                    foreach (var item2 in deadParticleEffects)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            item2.SetActive(true);
                            item2.transform.position = item.transform.position;
                            item2.GetComponent<ParticleSystem>().Play();
                            break;
                        }
                        
                    }
                    item.transform.position = Vector3.zero;
                    item.gameObject.SetActive(false);
                }
                GameManager.counterOfCharacters = 1;

            }
            else
            {
                int number3 = 0;
                foreach (var item in objectPooling)
                {
                    if (number3 != processNumber)
                    {
                        if (item.activeInHierarchy)
                        {
                            foreach (var item2 in deadParticleEffects)
                            {
                                if (!item2.activeInHierarchy)
                                {
                                    item2.SetActive(true);
                                    item2.transform.position = item.transform.position;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    break;
                                }

                            }


                            item.transform.position = Vector3.zero;
                            item.gameObject.SetActive(false);
                            number3++;

                        }
                    }
                    else
                    {
                        number3 = 0;
                        break;
                    }

                }
                GameManager.counterOfCharacters -= 4;
            }

        }

        public static void Division(int processNumber, List<GameObject> objectPooling, List<GameObject> deadParticleEffects)
        {

            if (GameManager.counterOfCharacters <= processNumber)
            {
                foreach (var item in objectPooling)
                {
                    foreach (var item2 in deadParticleEffects)
                    {
                        if (!item2.activeInHierarchy)
                        {
                            item2.SetActive(true);
                            item2.transform.position = item.transform.position;
                            item2.GetComponent<ParticleSystem>().Play();
                            break;
                        }

                    }
                    item.transform.position = Vector3.zero;
                    item.gameObject.SetActive(false);
                }
                GameManager.counterOfCharacters = 1;

            }
            else
            {
                int division = GameManager.counterOfCharacters / processNumber;

                int number3 = 0;
                foreach (var item in objectPooling)
                {
                    if (number3 != division)
                    {
                        if (item.activeInHierarchy)
                        {

                            foreach (var item2 in deadParticleEffects)
                            {
                                if (!item2.activeInHierarchy)
                                {
                                    item2.SetActive(true);
                                    item2.transform.position = item.transform.position;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    break;
                                }

                            }
                            item.transform.position = Vector3.zero;
                            item.gameObject.SetActive(false);
                            number3++;

                        }
                    }
                    else
                    {
                        number3 = 0;
                        break;
                    }

                }

                if (GameManager.counterOfCharacters % processNumber == 0)
                {
                    GameManager.counterOfCharacters /= processNumber;
                }
                else if (GameManager.counterOfCharacters % processNumber == 1)
                {
                    GameManager.counterOfCharacters /= processNumber;
                    GameManager.counterOfCharacters++;
                }
                else if (GameManager.counterOfCharacters % processNumber == 2)
                {
                    GameManager.counterOfCharacters /= processNumber;
                    GameManager.counterOfCharacters+=2;
                }
            }

        }
    }
}