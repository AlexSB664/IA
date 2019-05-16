using System.Collections;
using System.Collections.Generic;
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
  

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Raycast variables.
        

        //Raycasting mechanics.
       

            Invoke("Tomar", 5f);

        
         if (objeto.transform.position.x <= -2.40 && objeto.transform.position.y >= 1.40)
        {
            Invoke("Clasificar",5f);
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
                haveObject = false;
                carryObject.GetComponent<Rigidbody>().useGravity = true;
                objeto.transform.position = frutas.transform.position;
                carryObject = null;
            }
       
    }
}
