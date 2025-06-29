using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Over_X_Function : MonoBehaviour
{
    [Header("Graph Settings")]
    [Header("y = a/x")]
    [SerializeField] float a;
    [Space]
    [SerializeField] bool show_axis;
    [SerializeField] float limit;
    [Range(0.05f, 5f)]
    [SerializeField] float resolution;

    [Space]
    [Header("Analyzed Number")]
    [SerializeField] float number;
    [Space]
    [SerializeField] float evaluation;

    private List<Vector3> vectors = new List<Vector3>();

    private void Update()
    {
        // Calculating this function with it's limit
        for (float i = -limit; i < limit; i += resolution)
        {
            if(i == 0 || Mathf.Abs(a/i) > limit || i > limit) continue;
            vectors.Add(new Vector3(i, 0f, a/i));
        }

        // Plotting the function
        for (int i = 0; i < vectors.Count - 1; i++)
        {
            if(vectors[i].x < 0 && vectors[i + 1].x > 0) continue;
            Debug.DrawLine(vectors[i], vectors[i + 1]);
        }

        vectors.Clear();

        // Additional features
        Visualise_Examined_Number();
        ShowAxis();
    }

    private void Visualise_Examined_Number()
    {
        // Calculating evaluation for the analyzed number
        evaluation = a / number;

        // Visualising analyzed number value on Y axis
        if (number >= 0) Debug.DrawLine(new Vector3(0f, 0f, evaluation), new Vector3(-0.5f, 0f, evaluation), Color.red);
        else Debug.DrawLine(new Vector3(0f, 0f, evaluation), new Vector3(0.5f, 0f, evaluation), Color.red);

        // Visualising analyzed number value on X axis
        if (evaluation >= 0) Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, -0.5f), Color.blue);
        else Debug.DrawLine(new Vector3(number, 0f, 0f), new Vector3(number, 0f, 0.5f), Color.blue);

        // Rendering lines that point evaluation on the graph
        Debug.DrawLine(new Vector3(number, 0, 0), new Vector3(number, 0, evaluation), Color.green);
        Debug.DrawLine(new Vector3(0, 0, evaluation), new Vector3(number, 0, evaluation), Color.green);
    }

    private void ShowAxis()
    {
        if (show_axis)
        {
            // Plotting X and Y axis
            Debug.DrawLine(new Vector3(-limit, 0, 0), new Vector3(limit, 0, 0));
            Debug.DrawLine(new Vector3(0, 0, -limit), new Vector3(0, 0, limit));
        }
    }
}
