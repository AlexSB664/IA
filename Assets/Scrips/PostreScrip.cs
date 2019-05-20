using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PostreScrip : MonoBehaviour
{
    public float interactDistance = 3;
    public float carryDistance = 2.5f;
    public LayerMask interactLayer;

    private Transform carryObject;
    private bool haveObject;

    public GameObject objeto;
    public GameObject posicion;


    public AudioSource a1;
    public AudioSource a2;
    public AudioSource PieCorrecto;
    public AudioSource PastelCorrecto;
    public AudioSource NieveCorrecto;
    public AudioSource errorPie;
    public AudioSource errorPastel;
    public AudioSource errorNieve;
    public Text Texto;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Invoke("Tomar", 3f);

        if (objeto.transform.position.x >= 2.40 && objeto.transform.position.y >= 1.70)
        {

            Invoke("Clasificar", 3f);
        }
        if (objeto.transform.position.x <= -2.40 && objeto.transform.position.y >= 1.40)
        {

            a2.Play();
            Invoke("Error", 2f);
        }

        if (haveObject)
        {
            carryObject.position = Vector3.Lerp(carryObject.position, Camera.main.transform.position + Camera.main.transform.forward * carryDistance, Time.deltaTime * 8);
            carryObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

    }
    public void Clasificar()
    {

        if (haveObject)
        {
            a1.Play();
            haveObject = false;
            carryObject.GetComponent<Rigidbody>().useGravity = true;
            objeto.transform.position = posicion.transform.position;
            carryObject = null;

            Invoke("Sonido", 1f);
        }

    }

    public void Sonido()
    {
        if (objeto.name == "Pie")
        {
            PieCorrecto.Play();
            Texto.text = "Correcto el Pie es un Postre!!";
            Invoke("Limpiar", 3f);
        }

        if (objeto.name == "Pastel")
        {
            PastelCorrecto.Play();
            Texto.text = "Correcto el Pastel es un Postre!!";
            Invoke("Limpiar", 3f);
        }

        if (objeto.name == "Nieve")
        {
            NieveCorrecto.Play();
            Texto.text = "Correcto el Helado es un Postre!!";
            Invoke("Limpiar", 3f);
        }

    }

    private void Error()
    {
        if (objeto.name == "Pie")
        {
            errorPie.Play();
            Texto.text = "No el Pie no es Chatarra";
            Invoke("Limpiar", 3f);
        }

        if (objeto.name == "Pastel")
        {
            errorPastel.Play();
            Texto.text = "No el Pastel no es Chatarra";
            Invoke("Limpiar", 3f);
        }

        if (objeto.name == "Nieve")
        {
            errorNieve.Play();
            Texto.text = "No el Helado no es Chatarra";
            Invoke("Limpiar", 3f);
        }
    }


    private void Limpiar()
    {
        Texto.text = "";
    }
    public void Tomar()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            carryObject = hit.transform;
            carryObject.GetComponent<Rigidbody>().useGravity = false;
            haveObject = true;
        }
    }
}
