using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder_1 : MonoBehaviour
{

    [Header("Exploring Border")]
    [SerializeField] private int x_border;
    [SerializeField] private int y_border;
    
    [Space]
    [Header("Other Info : Read Only")]
    [SerializeField] private int possible_outcomes;

    //private RaycastHit hit;

    //[SerializeField] private float ray_distance;

    private float elapsed_time;
    [SerializeField] private float period;

    private void Update()
    {
        Debug.DrawLine(new Vector3(transform.position.x, 1f, transform.position.z), transform.forward);

        //Drawing our x border
        Debug.DrawLine(new Vector3(x_border, 0f, -y_border), new Vector3(x_border, 0f, y_border));
        Debug.DrawLine(new Vector3(-x_border, 0f, -y_border), new Vector3(-x_border, 0f, y_border));

        //Drawing our y border
        Debug.DrawLine(new Vector3(-x_border, 0f, y_border), new Vector3(x_border, 0f, y_border));
        Debug.DrawLine(new Vector3(-x_border, 0f, -y_border), new Vector3(x_border, 0f, -y_border));

        //Ray instancing
        //Ray ray = new Ray(new Vector3(transform.position.x, 1f, transform.position.z), transform.forward);
        //if (Physics.Raycast(ray, out hit, ray_distance))
        //{
        //    DetectetObject();
        //}

        //Callculating all possiblke outcomes depending on our seeking area.
        possible_outcomes = (x_border * y_border) * 4;

        //Making move each time elapsed time variable hits period timing
        elapsed_time += Time.deltaTime;
        if (elapsed_time > period)
        {
            MakeMove();
            elapsed_time = 0;
        }

    }

    public void DetectetObject()
    {
        Debug.Log("Your robot is facing an object");
    }

    public void MakeMove()
    {
        if(transform.position.x >= x_border)
        {
            transform.rotation = Quaternion.Euler(0f, 270, 0f);
            transform.position += transform.forward;
        } 
        else if(transform.position.x <= -x_border)
        {
            transform.rotation = Quaternion.Euler(0f, 90, 0f);
            transform.position += transform.forward;
        }
        else if(transform.position.z >= y_border)
        {
            transform.rotation = Quaternion.Euler(0f, 180, 0f);
            transform.position += transform.forward;
        }
        else if(transform.position.z <= -y_border)
        {
            transform.rotation = Quaternion.Euler(0f, 0, 0f);
            transform.position += transform.forward;
        }
        else
        {
            int random_rotation = Random.Range(0, 4) * 90;
            transform.rotation = Quaternion.Euler(0f, random_rotation, 0f);
            transform.position += transform.forward;
        }
    }
}
