using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{

    //declaramos las camaras que tenemos/usaremos
    [SerializeField] Camera mainCamera, secondaryCamera;

    //declaramos los objetos correspondientes a los botones con los que cambiaremos tanto las camaras (entre la principal y la secoundaria) como las posiciones de la secundaria
    [SerializeField] GameObject switchCamera, nextPosition;

    //declaramos una lista con las posiciones que tomara la segunda camara
    [SerializeField] List<GameObject> positions;

    //declaramos un contador que nos dira en que posicion esta la camara
    int position_Counter = 0;
    
    void Start(){
        update_Current_Position();
    }

    public void switch_Camera(){//funcion con la que cambiaremos de camara entre la principal y la secundaria
        if (mainCamera.enabled)
        {
            mainCamera.enabled = false;
            secondaryCamera.enabled = true;
            nextPosition.SetActive(true);
        }
        else
        {
            mainCamera.enabled = true;
            secondaryCamera.enabled = false;
            nextPosition.SetActive(false);
        }
    }

    private void update_Current_Position(){//funcion con la que actualizaremos la posicion y rotacion de la camara
        secondaryCamera.transform.position = positions[position_Counter].transform.position;
        secondaryCamera.transform.rotation = positions[position_Counter].transform.rotation;
    }

    public void jump_To_Next_Position(){//funcion con la que cambiaremos de posicion en la camara secundaria
        position_Counter = position_Counter == positions.Count - 1 ? 0 : position_Counter + 1;
        update_Current_Position();
    }
}
