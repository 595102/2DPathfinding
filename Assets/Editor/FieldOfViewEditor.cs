using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
     void OnSceneGUI()
     {
        FieldOfView fov = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(new Vector3(fov.transform.position.x + fov.OffsetX, fov.transform.position.y + fov.OffsetY, fov.transform.position.z) , Vector3.forward, Vector3.up, 360, fov.viewRadius);
        Vector3 viewAngleA = fov.DirFromAngle(-fov.viewAngle / 2, false);
        Vector3 viewAngleB = fov.DirFromAngle(fov.viewAngle / 2, false);

        Handles.DrawLine(new Vector3(fov.transform.position.x + fov.OffsetX, fov.transform.position.y + fov.OffsetY, fov.transform.position.z), new Vector3(fov.transform.position.x + fov.OffsetX, fov.transform.position.y + fov.OffsetY, fov.transform.position.z) + viewAngleA * fov.viewRadius);
        Handles.DrawLine(new Vector3(fov.transform.position.x + fov.OffsetX,fov.transform.position.y + fov.OffsetY,fov.transform.position.z), new Vector3(fov.transform.position.x + fov.OffsetX, fov.transform.position.y + fov.OffsetY, fov.transform.position.z) + viewAngleB * fov.viewRadius);

        Handles.color = Color.red;
        foreach (Transform visibleTarget in fov.visibleTargets)
        {
            Handles.DrawLine(new Vector3(fov.transform.position.x + fov.OffsetX, fov.transform.position.y + fov.OffsetY, fov.transform.position.z), visibleTarget.position);
        }
     }
}
