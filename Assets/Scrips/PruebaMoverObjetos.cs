using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PruebaMoverObjetos : MonoBehaviour
{
    public float interactDistance = 3;
    public float carryDistance = 2.5f;
    public LayerMask interactLayer;

    private Transform carryObject;
    private bool haveObject;

    public GameObject objeto;
    public GameObject frutas;


    public AudioSource a1;
    public AudioSource a2;
    public AudioSource bananaCorrecto;
    public AudioSource naranjaCorrecto;
    public AudioSource manzanaCorrecto;
    public AudioSource errorbanana;
    public AudioSource errornaranja;
    public AudioSource errormanzana;
    public Text Texto;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

       
            Invoke("Tomar", 3);

            if (objeto.transform.position.x >= 2.40 && objeto.transform.position.y >= 1.70)
            {
                a2.Play();
                Invoke("Error", 2f);
            }
         if (objeto.transform.position.x <= -2.40 && objeto.transform.position.y >= 1.40)
        {
            Invoke("Clasificar",3);
        }

        //If we have an object in hand, we update its position and smooth it out with basic interpolation.
        if (haveObject)
        {
            carryObject.position = Vector3.Lerp(carryObject.position, Camera.main.transform.position + Camera.main.transform.forward * carryDistance, Time.deltaTime * 8);
            carryObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

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

    public void Clasificar()
    {
        
            if (haveObject)
            {
                a1.Play();
                haveObject = false;
                carryObject.GetComponent<Rigidbody>().useGravity = true;
                objeto.transform.position = frutas.transform.position;
                carryObject = null;

                Invoke("Sonido",1f);
            }
       
    }

    public void Sonido()
    {
        if (objeto.name == "banana")
        {
            bananaCorrecto.Play();
            Texto.text = "Correcto el Platano es una Fruta!!";
            Invoke("Limpiar", 3f);
        }

        if (objeto.name == "Orange")
        {
            naranjaCorrecto.Play();
            Texto.text = "Correcto la Naranja es una Fruta!!";
            Invoke("Limpiar", 3f);
        }

        if (objeto.name == "Manzana")
        {
            manzanaCorrecto.Play();
            Texto.text = "Correcto la Manzana es una Fruta!!";
            Invoke("Limpiar", 3f);
        }
    
    }
    private void Error()
    { 
       if (objeto.name == "banana")
        {
            errorbanana.Play();
            Texto.text = "No el Platano no es una verdura";
            Invoke("Limpiar", 3f);
        }

        if (objeto.name == "Orange")
        {
            errornaranja.Play();
            Texto.text = "No la Naranja no es una verdura";
            Invoke("Limpiar", 3f);
        }

        if (objeto.name == "Manzana")
        {
            errormanzana.Play();
            Texto.text = "No la Manzana no es una verdura";
            Invoke("Limpiar", 3f);
        }
    }

    private void Limpiar()
    {
        Texto.text = "";
    }
}
