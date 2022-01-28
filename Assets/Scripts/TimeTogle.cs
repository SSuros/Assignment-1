using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTogle : MonoBehaviour
{
    public GameObject Present;
    public GameObject Past;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(Present.activeSelf)
            {
                Present.SetActive(false);
                Past.SetActive(true);
            }
            else
            {
                Present.SetActive(true);
                Past.SetActive(false);
            }
            
        }
    }
}
