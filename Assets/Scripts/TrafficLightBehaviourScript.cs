using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightBehaviourScript : MonoBehaviour
{

    private int colorIndex;
    public float timeFloat;

    public Material[] mats = new Material[3];

    // Start is called before the first frame update
    void Start()
    {

        colorIndex = Random.Range(0, 3);
        updateColor();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateColor()
    {

        if (colorIndex <= 0)
        {
            gameObject.tag = "GreenLight";
            gameObject.GetComponent<MeshRenderer>().material = mats[0];
            timeFloat = Random.Range(5f, 10f);
            Invoke("changeToYellow", timeFloat);
        }

        if (colorIndex == 1)
        {
            gameObject.tag = "YellowLight";
            gameObject.GetComponent<MeshRenderer>().material = mats[1];
            timeFloat = 4f;
            Invoke("changeToRed", timeFloat);
        }

        if (colorIndex >= 2)
        {
            gameObject.tag = "RedLight";
            gameObject.GetComponent<MeshRenderer>().material = mats[2];
            timeFloat = Random.Range(5f, 10f);
            Invoke("changeToGreen", timeFloat);
        }

    }

    public void changeToYellow()
    {

        colorIndex = 1;
        
        updateColor();

    }

    public void changeToRed()
    {

        colorIndex = 2;
        
        updateColor();

    }

    public void changeToGreen()
    {

        colorIndex = 0;
        
        updateColor();

    }

}
