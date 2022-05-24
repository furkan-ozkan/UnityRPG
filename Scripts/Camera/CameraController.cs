using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float cameraFollowSpeed;
    [SerializeField] [Range(0, 50)]
    private float screenRotateEdgeSize;
    [SerializeField] [Range(0, 100)]
    private float screenRotateSpeed;

    void Update()
    {
        Vector3 dir = (player.transform.position - transform.position).normalized;
        if (Vector3.Distance(transform.position,player.transform.position)>0.1f)
        {
            transform.position += dir * Time.deltaTime * cameraFollowSpeed;
        }

        if (Input.mousePosition.x >Screen.width - screenRotateEdgeSize)
        {
            transform.eulerAngles -= Vector3.up * Time.deltaTime * screenRotateSpeed;
        }
        if (Input.mousePosition.x < screenRotateEdgeSize)
        {
            transform.eulerAngles += Vector3.up * Time.deltaTime * screenRotateSpeed;
        }
    }
}
