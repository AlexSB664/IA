using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverObjetos : MonoBehaviour
{
    public Transform playerTf;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerTf.position = new Vector3(playerTf.position.x, playerTf.position.y, playerTf.position.z);
    }
}
