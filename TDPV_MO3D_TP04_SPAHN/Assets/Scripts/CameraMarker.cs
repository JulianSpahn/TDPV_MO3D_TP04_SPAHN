using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMarker : MonoBehaviour
{
    public float cSize = 10f;//definimos el tamaño del cubo
    private void OnDrawGizmos()//duncion con la que dibujaremos el cubo verde y la linea roja que lo atravieza
    {
        //cubo
        Gizmos.color = Color.green;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawCube(Vector3.zero, new Vector3(cSize, cSize, cSize));
        //linea
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, new Vector3(transform.forward.x, transform.forward.y, transform.forward.z + 150));
    }
}
