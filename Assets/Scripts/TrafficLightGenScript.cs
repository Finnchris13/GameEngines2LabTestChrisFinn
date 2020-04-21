using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightGenScript : MonoBehaviour
{

    public GameObject trafficLightPrefab;
    GameObject[] trafficLights = new GameObject[10];

    // Start is called before the first frame update
    void Start()
    {

        gameObject.transform.position = Vector3.zero;

        for (int i = 0; i < 10; i++)
        {
            GameObject instantiatedLights = Instantiate(trafficLightPrefab);
            instantiatedLights.transform.position = this.transform.position;
            instantiatedLights.transform.parent = this.transform;
            this.transform.eulerAngles = new Vector3(0, 36 * i, 0);
            instantiatedLights.transform.position = Vector3.forward * 10;
            trafficLights[i] = instantiatedLights;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
