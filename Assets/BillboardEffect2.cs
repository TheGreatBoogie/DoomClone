using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardEffect2 : MonoBehaviour
{

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerMove>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        // Look oposite direction
        //transform.LookAt(transform.position - (target.position - transform.position));
        
    }
}
