using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotSystem : MonoBehaviour
{
    public float speed = 90;

    // Update is called once per frame
    void Update()
    {
        // for plane dynamic ...

        //transform.position += transform.forward * Time.deltaTime * speed;
        transform.position += transform.forward * Time.deltaTime * speed;

        speed -= transform.forward.y * Time.deltaTime * 50.0F;

        // limit the speed om 35 on taing off ...
        if(speed < 35.0f)
        {
            speed = 35.0f;
        }

        transform.Rotate(Input.GetAxis("Vertical"), 0.0f, -Input.GetAxis("Horizontal"));
        float planeHight = Terrain.activeTerrain.SampleHeight(transform.position);
        if(planeHight> transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, planeHight, transform.position.z);
        }
    }
}
