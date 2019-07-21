using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempo : MonoBehaviour
{
    public GameObject arrow;
    public GameObject stringPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(arrow.transform.position);
        Debug.Log(stringPoint.transform.position);
        Debug.Log(stringPoint.transform.localPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
