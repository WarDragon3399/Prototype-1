using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer2edCam : MonoBehaviour
{
    public GameObject player2;
    private Vector3 offset = new Vector3(5, 6.9f, -12.8f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player2.transform.position + offset;
    }
}
