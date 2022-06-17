using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollactedCube : MonoBehaviour
{
    CollectManager collectManager;

    void Start()
    {
        collectManager = CollectManager.instance;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Collactable Cube" && !(other.gameObject.GetComponent<CollactableCube>().collacted))
        {
            other.gameObject.GetComponent<CollactableCube>().collacted = true;
            Destroy(other.gameObject);
            collectManager.AddCube();
        }

        if(other.gameObject.tag == "Block")
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            collectManager.RemoveCube(gameObject);
        }

        if(other.gameObject.tag == "Finish Block")
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            collectManager.RemoveCubeFinish(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish Line")
        {
            collectManager.FinishCamPos();
        }

        if (other.gameObject.tag == "Finish")
        {
            collectManager.FinishSettings();
        }

        if (other.gameObject.tag == "Cuboid")
        {
            collectManager.DiamondIconCreate(other.gameObject.transform);
            Destroy(other.gameObject);
        }

    }

}
