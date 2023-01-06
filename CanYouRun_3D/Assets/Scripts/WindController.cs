using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("AICharacter"))
        {
            other.GetComponent<Rigidbody>().AddForce(new Vector3(-4, 0, 0), ForceMode.Impulse);
        }
    }
}
