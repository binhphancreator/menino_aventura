using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private Vector3 newtrans;

void Start ()
{
    offset = transform.position - player.transform.position;
}

void LateUpdate ()
{
    Quaternion camOrbitAngle1 = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 5f, Vector3.up);
    Quaternion camOrbitAngle2 = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * 5f, Vector3.forward);
    offset = camOrbitAngle1 * offset;
    offset = camOrbitAngle2 * offset;
    transform.LookAt(player.transform);

    newtrans = player.transform.position + offset;
    transform.position = Vector3.Slerp(transform.position, newtrans, 0.1f);
}
}

