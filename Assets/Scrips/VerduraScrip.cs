using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VerduraScrip : MonoBehaviour
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
    public AudioSource CalabazaCorrecto;
    public AudioSource EloteCorrecto;
    public AudioSource PapaCorrecto;
    public AudioSource errorElote;
    public AudioSource errorPapa;
    public AudioSource errorCalabaza;
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
        if (objeto.name == "Calabaza")
        {
            CalabazaCorrecto.Play();
            Texto.text = "Correcto la Calabaza es una Verdura!!";
            Invoke("Limpiar", 3f);
        }

        if (objeto.name == "Elote")
        {
            EloteCorrecto.Play();
            Texto.text = "Correcto el Elote es una Verdura!!";
            Invoke("Limpiar", 3f);
        }

        if (objeto.name == "Papa")
        {
            PapaCorrecto.Play();
            Texto.text = "Correcto la Papa es una Verdura!!";
            Invoke("Limpiar", 3f);
        }

    }

    private void Error()
    {
        if (objeto.name == "Elote")
        {
            errorElote.Play();
            Texto.text = "No el Elote no es una Fruta";
            Invoke("Limpiar", 3f);
        }

        if (objeto.name == "Calabaza")
        {
            errorCalabaza.Play();
            Texto.text = "No la Calabaza no es una Fruta";
            Invoke("Limpiar", 3f);
        }

        if (objeto.name == "Papa")
        {
            errorPapa.Play();
            Texto.text = "No la Papa no es una Fruta";
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
