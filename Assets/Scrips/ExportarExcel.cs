using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class ImportarExcel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        nombreU.text = "Nombre de Usuario: " + Perfil.NombreUsuario;
        Edad.text = "Edad: " + Perfil.Edad.ToString();
        nombre.text = "Nombre: " + Perfil.Nombre;
        fallos.text = "Fallos: " + Perfil.Fallos.ToString();
        aciertos.text = "Aciertos: " + Perfil.Aciertos.ToString();
        string ruta = Application.persistenDataPath +"/";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
