using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace lga238 {
public class Move : MonoBehaviour
{

    // Use this for initialization
    public float speed;

    public float currentSpeed;
    private bool moving = false;
    private bool easingMovement = true;

    void Start()
    {
        speed = 10.0f;
        currentSpeed = 0;

    }

    // Update is called once per frame
    void Update()
    {
        checkHit();
    }

    public void checkHit()
    {

        RaycastHit hit;
    // check if raycast intersects griund plane
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if (hit.transform.name == "Ground")
            {   
                //teleport to location if distance is less than 10; y value remains the same
                if (hit.distance <= 10.0f)
                {
                    var tempPoints = hit.point;
                    tempPoints.y = transform.position.y;
                    transform.position = tempPoints;
                }
                // if raycast collision distance is greater than 10, move to location normally
                else
                {
                    //transform.position+= Camera.main.transform.forward * speed * Time.deltaTime;

                    moving = true;
                    if (easingMovement)
                    {
                        //accelarate
                        if (currentSpeed < speed)
                        {
                            currentSpeed = currentSpeed + (0.01f * speed);
                        }
                        transform.position += Camera.main.transform.forward * currentSpeed * Time.deltaTime;
                    }
                }
            }

        }

        else if (moving)
        {
            if (currentSpeed > 0)
            {
                currentSpeed = currentSpeed - (0.01f * speed);
            }

            else
            {
                moving = false;
            }
            //decelerate 
            transform.position += Camera.main.transform.forward * currentSpeed * Time.deltaTime;
        }
    }
}

}