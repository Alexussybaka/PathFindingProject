using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_Controller : MonoBehaviour
{
    [Header("Circle : Preferences")]
    [Range(1, 360)]
    [SerializeField] int subdivisions_count;
    [SerializeField] bool show_subdivisions;
    [Space]

    [SerializeField] float radius;
    [SerializeField] Vector3 center;
    [Space]

    [Header("Info : Read Only")]
    [SerializeField] float area;

    private List<Vector3> rotated_points = new List<Vector3>();

    private void Update()
    {
        area = Mathf.PI * (radius * radius);

        float angle = (360 / subdivisions_count) / (180 / Mathf.PI);

        for (int i = 1; i < subdivisions_count+1; i++)
        {
            // Safe procedures to ensure we don't get zero division error.
            if(subdivisions_count == 0) return;

            float x_pos = radius * Mathf.Cos(angle * i);
            float y_pos = radius* Mathf.Sin(angle * i);

            Vector3 rotation_point = new Vector3(x_pos, 0f, y_pos);
            rotated_points.Add(rotation_point);

            if(show_subdivisions) Debug.DrawLine(center, rotation_point);
        }

        for (int i = 0; i < rotated_points.Count -1; i++)
        {
            Debug.DrawLine(rotated_points[i], rotated_points[i+1]);
        }
        Debug.DrawLine(rotated_points[rotated_points.Count-1], rotated_points[0]);

        rotated_points.Clear();
    }
}
