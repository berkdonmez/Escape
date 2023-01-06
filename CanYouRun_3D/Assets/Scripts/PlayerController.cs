using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject Camera;
    public bool IsFinish;
    public GameObject FinisPoint;

    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (!IsFinish)
        {
            transform.Translate(Vector3.forward * .5f * Time.deltaTime);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFinish == true)
        {
            transform.position = Vector3.Lerp(transform.position, FinisPoint.transform.position, .015f);
        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (Input.GetAxis("Mouse X") < 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - .05f, transform.position.y, transform.position.z), .3f);
                }

                if (Input.GetAxis("Mouse X") > 0)
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + .05f, transform.position.y, transform.position.z), .3f);
                }
            }
        }

      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Multiplication") || other.gameObject.CompareTag("Division") || other.gameObject.CompareTag("Addication") || other.gameObject.CompareTag("Extraction"))
        {
            int processNumber = int.Parse(other.name);
            gameManager.CharacterManager(other.gameObject.tag,processNumber ,other.gameObject.transform);    
            //Debug.Log(other.gameObject.name);
        }

        else if (other.gameObject.CompareTag("LastTrigger"))
        {
            Camera.GetComponent<CameraController>().IsFinish = true;
            gameManager.EnemiesTrigger();
            IsFinish = true;
        }
    }
}
