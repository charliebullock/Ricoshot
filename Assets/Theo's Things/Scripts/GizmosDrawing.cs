using System;
using UnityEditor;
using UnityEngine;

public enum GizmosShapes
{
    WireCube,
    FilledCube,
    FilledSphere,
    WireSphere,
    WireCapsule,
    Nothing
}
public class GizmosDrawing : MonoBehaviour
{
    [SerializeField] private GizmosShapes gizmosShapes;
    [SerializeField] private Color gizmosColour;
    [SerializeField] private Vector3 cubeSize;
    [SerializeField] private float radius;
    [SerializeField] private float height;

    private void OnDrawGizmos()
    {
        Gizmos.color = gizmosColour;
        switch (gizmosShapes)
        {
            case GizmosShapes.WireCube:
                Gizmos.DrawWireCube(transform.position,cubeSize);
                break;
            case GizmosShapes.FilledCube:
                Gizmos.DrawCube(transform.position,cubeSize);
                break;
            case GizmosShapes.FilledSphere:
                Gizmos.DrawSphere(transform.position,radius);
                break;
            case GizmosShapes.WireSphere:
                Gizmos.DrawWireSphere(transform.position,radius);
                break;
            case GizmosShapes.WireCapsule:
                DrawWireCapsule(transform.position, transform.rotation, radius,height,gizmosColour);
                break;
            case GizmosShapes.Nothing:
                break;
        }
    }

    private static void DrawWireCapsule(Vector3 pos, Quaternion rot, float radius, float height, Color color)
    {
        //if (color != default)
        //{
        //    Handles.color = color;   
        //}
        //Matrix4x4 angleMatrix = Matrix4x4.TRS(pos, rot, Handles.matrix.lossyScale);
        //using (new Handles.DrawingScope(angleMatrix))
        //{
        //    float pointOffset = (height - (radius * 2)) / 2;
 
        //    //draw sideways
        //    Handles.DrawWireArc(Vector3.up * pointOffset, Vector3.left, Vector3.back, -180, radius);
        //    Handles.DrawLine(new Vector3(0, pointOffset, -radius), new Vector3(0, -pointOffset, -radius));
        //    Handles.DrawLine(new Vector3(0, pointOffset, radius), new Vector3(0, -pointOffset, radius));
        //    Handles.DrawWireArc(Vector3.down * pointOffset, Vector3.left, Vector3.back, 180, radius);
        //    //draw frontways
        //    Handles.DrawWireArc(Vector3.up * pointOffset, Vector3.back, Vector3.left, 180, radius);
        //    Handles.DrawLine(new Vector3(-radius, pointOffset, 0), new Vector3(-radius, -pointOffset, 0));
        //    Handles.DrawLine(new Vector3(radius, pointOffset, 0), new Vector3(radius, -pointOffset, 0));
        //    Handles.DrawWireArc(Vector3.down * pointOffset, Vector3.back, Vector3.left, -180, radius);
        //    //draw center
        //    Handles.DrawWireDisc(Vector3.up * pointOffset, Vector3.up, radius);
        //    Handles.DrawWireDisc(Vector3.down * pointOffset, Vector3.up, radius);
 
    //    }
    }
}
