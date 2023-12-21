using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CameraConfigurator : MonoBehaviour
{
    //declaramos la camara
    [SerializeField] Camera mainCamera;

    //declaramos los objetos que usaremos, el primero es el texto del boton que hace el switch (este cambiara una vez lo precionemos y dira que tipo de proyeccion usamos)
    //y los otros 2 objetos corresponden a cada tipo de proyeccion, estan separados para que, cuando se cambie, no aparezcala barra correspondiente al que no se usa.
    [SerializeField] GameObject switchButtonText;
    [SerializeField] GameObject orthographic;
    [SerializeField] GameObject perspective;

    //declaramos las variables (son del tipo slider para poder ser manejadas por las barras del proyecto)
    [SerializeField] Slider fov_Slider_Bar, size_Slider_Bar;
    [SerializeField] Slider nearClipPlane_Slider_Bar, farClipPlane_Slider_Bar;

    //declaramos los rangos que manejaran las variables
    [Range(0, 180)] float Fov;
    [Range(0, 100)] float Size;
    [Range(0, 100)] float NearClipPlane;
    [Range(0, 1000)] float FarClipPlane;

    //declaramos el booleano que nos dira si cambiamos de entre vista ortografica y perspectiva
    bool is_It_Orthographic;

    private void Start()//inicializamos los elementos
    {
        if (mainCamera != null)
        { 
            fov_Slider_Bar.value = Fov = mainCamera.fieldOfView;
            size_Slider_Bar.value = Size = mainCamera.orthographicSize;
            nearClipPlane_Slider_Bar.value = NearClipPlane = mainCamera.nearClipPlane;
            farClipPlane_Slider_Bar.value = FarClipPlane = mainCamera.farClipPlane;
        }
    }

    private void update_Projection_Elements()//funcion encargada de actualizar el tipo de proyeccion entre la ortografica y la perspectiva
    {
        orthographic.SetActive(is_It_Orthographic);
        perspective.SetActive(!is_It_Orthographic);
        switchButtonText.GetComponent<TextMeshProUGUI>().text = is_It_Orthographic ? "Orthographic" : "Perspective";
    }

    public void switch_Projection()//funcion encargada de cambiar el tipo de proyeccion
    {
        is_It_Orthographic = mainCamera.orthographic = !is_It_Orthographic;
        update_Projection_Elements();
    }

    public void update_Fov(float fov_Value)//funcion encargada de actualizar constantemente el fov en la camara
    {
        fov_Slider_Bar.value = Fov = mainCamera.fieldOfView = fov_Value;
    }

    public void update_Size(float size_Value)//funcion encargada de actualizar constantemente el size en la camara
    {
        size_Slider_Bar.value = Size = mainCamera.orthographicSize = size_Value;
    }

    public void update_NearClipPlane(float ncp_Value)//funcion encargada de actualizar constantemente el near clip plane en la camara
    {
        nearClipPlane_Slider_Bar.value = NearClipPlane = mainCamera.nearClipPlane = ncp_Value;
    }

    public void update_FarClipPlane(float fcp_Value)//funcion encargada de actualizar constantemente el dar clip plane en la camara
    {
        farClipPlane_Slider_Bar.value = FarClipPlane = mainCamera.farClipPlane = fcp_Value;
    }

    public void OnDrawGizmos()//Actualizacion: dibujamos el Gizmo amarillo del frustum y los rojos de la esfera y la linea;
    {
        Gizmos.color = Color.yellow;
        Gizmos.matrix = transform.localToWorldMatrix;
        //Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, new Vector3(GetComponent<Camera>().aspect, 1.0f, 1.0f));
        Gizmos.DrawFrustum(Vector3.zero, GetComponent<Camera>().fieldOfView, GetComponent<Camera>().farClipPlane, GetComponent<Camera>().nearClipPlane, 1.0f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(Vector3.zero, 15f);
        Gizmos.DrawLine(Vector3.zero, new Vector3(transform.forward.x, transform.forward.y, transform.forward.z + 150));
    }
}
