using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    public bool followCam = true;
    private Vector3 startDistance, moveVec;

    void Start()
    {
        startDistance = transform.position;
    }

    void Update()
    {
        if (followCam)
        {
            moveVec.y = startDistance.y;
            moveVec.x = Mathf.Lerp(transform.position.x, player.transform.position.x, 5f * Time.deltaTime);
            moveVec.z = Mathf.Lerp(transform.position.z, player.transform.position.z - 5f, 5f * Time.deltaTime);
            transform.position = moveVec;
        }
    }
}
