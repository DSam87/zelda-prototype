using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    public string areaToLoad;
    private string areaToTransitionName;

    // Start is called before the first frame update
    void Start()
    {
        areaToTransitionName = areaToLoad;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            PlayerController.instance.areaToTransitionName = areaToTransitionName;
            SceneManager.LoadScene(areaToLoad);
        }
    }
}
