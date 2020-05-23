using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomController : MonoBehaviour
{
    public float zoomSize = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            
                zoomSize -= 1;
            
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            
                zoomSize += 1;
            
        }

        GetComponent<Camera>().orthographicSize = zoomSize;
    }
}
