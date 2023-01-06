using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    public bool IsFinish;
    public GameObject CameraFinishPosition;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!IsFinish)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, .125f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, CameraFinishPosition.transform.position, .015f);
        }

    }
}
