using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotRenderer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
     LineRenderer MyLineRenderer;

    Vector3 StartPosition, StartRotation;

    public int maxReflectionCount ;
    public float maxStepDistance = 200;

    void Start()
    {
        if (MyLineRenderer == null)
            MyLineRenderer = GetComponent<LineRenderer>();
        maxReflectionCount = MyLineRenderer.positionCount - 1;


    }

    // Update is called once per frame
    void Update()
    {
        StartPosition = Vector3.zero;
        StartRotation = transform.forward;
        
        MyLineRenderer.SetPosition(0,StartPosition);

        DrawPredictionReflectionPattern(StartPosition, StartRotation, maxReflectionCount);
    }

    void DrawPredictionReflectionPattern(Vector3 position, Vector3 direction, int reflectionsRemaining)
    {

        if (reflectionsRemaining == 0)
        {
            return;
        }

        Ray ray = new Ray(position, direction);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxStepDistance))
        {
            direction = Vector3.Reflect(direction, hit.normal);
            position = hit.point;
        }
        else
        {
            position += direction * maxStepDistance;
        }

        MyLineRenderer.SetPosition((MyLineRenderer.positionCount - reflectionsRemaining),  position - transform.position);

        DrawPredictionReflectionPattern(position, direction, reflectionsRemaining - 1);
    }
}
