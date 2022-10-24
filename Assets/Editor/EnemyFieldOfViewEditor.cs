using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyFieldOfView))]
public class EnemyFieldOfViewEditor : Editor
{
    private void OnSceneGUI() 
    {
        EnemyFieldOfView enemyFOV = (EnemyFieldOfView) target;

        Handles.color = Color.white;
        Handles.DrawWireArc(enemyFOV.transform.position, Vector3.up, Vector3.forward, 360, enemyFOV.radius);    

        Vector3 viewAngle01 = DirectionFromAngle(enemyFOV.transform.eulerAngles.y, -enemyFOV.angle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(enemyFOV.transform.eulerAngles.y, enemyFOV.angle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(enemyFOV.transform.position, enemyFOV.transform.position + viewAngle01 * enemyFOV.radius);
        Handles.DrawLine(enemyFOV.transform.position, enemyFOV.transform.position + viewAngle02 * enemyFOV.radius);

        if(enemyFOV.canSeePlayer)
        {
            Handles.color = Color.green;
            Handles.DrawLine(enemyFOV.transform.position, enemyFOV.playerRef.transform.position);
        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
