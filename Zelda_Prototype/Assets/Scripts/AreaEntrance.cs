using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{

    public string intranceName;

    // Start is called before the first frame update
    void Start()
    {
        if(intranceName == PlayerController.instance.areaToTransitionName)
        {
            PlayerController.instance.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
