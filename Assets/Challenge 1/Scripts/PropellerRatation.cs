using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerRatation : MonoBehaviour
{
    // Variable for Ratation
    public Vector3 RotionChange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(RotionChange);
    }
}
