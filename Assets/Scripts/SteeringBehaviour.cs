using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviour : MonoBehaviour
{

    public float mass;
    public float maxVelocity;
    public float maxForce;
    public float stoppingDistance;
    public float stoppingVelocity;
    public float rotSpeed;
    private float nextTime = 1f;

    public Transform target;
    public GameObject[] greenLights;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;

        stoppingVelocity = maxVelocity / 2;

        Invoke("chooseRandomTarget", 0.05f);
    }

    // Update is called once per frame
    void Update()
    {

        if (target != null)
        {

            /*var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);*/

            var desiredVelocity = target.transform.position - transform.position;
            desiredVelocity = desiredVelocity.normalized * maxVelocity;

            var steering = desiredVelocity - velocity;
            steering = Vector3.ClampMagnitude(steering, maxForce);
            steering /= mass;

            velocity = Vector3.ClampMagnitude(velocity + steering, maxVelocity);
            transform.position += velocity * Time.deltaTime;
            transform.forward = velocity.normalized;

            Debug.DrawRay(transform.position, desiredVelocity.normalized * 6, Color.magenta);

            if (target.gameObject.tag != "GreenLight")
            {
                chooseRandomTarget();
            }

            float dist = Vector3.Distance(target.position, transform.position);

            if (dist < stoppingDistance)
            {
                maxVelocity = stoppingVelocity;
            }
            else
            {
                maxVelocity = stoppingVelocity * 2;
            }

        }

    }

    public void chooseRandomTarget()
    {
        greenLights = GameObject.FindGameObjectsWithTag("GreenLight");

        int randomIndex = Random.Range(0, greenLights.Length - 1);

        target = greenLights[randomIndex].transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GreenLight")
        {
            other.gameObject.tag = "YellowLight";
            chooseRandomTarget();
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "GreenLight")
        {
            if (Time.time > nextTime)
            {
                nextTime = Time.time + 0.3f;

                chooseRandomTarget();
            }
        }
    }*/

}
