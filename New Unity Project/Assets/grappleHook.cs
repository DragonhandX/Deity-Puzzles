using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grappleHook : MonoBehaviour {

    public GameObject character;


    private void Awake()
    {
        
    }



    private void OnCollisionEnter(Collision collision)
    {

        GameObject collide = collision.gameObject;

        if (collide.tag == "grappleSpot")
        {
            grappleTransport();
            Destroy(this.gameObject);
            Debug.Log("grapple hook hit a grapple spot...");
        }
        else
        {
            Destroy(this.gameObject);
            Debug.Log("grapple hook did not hit a grapple spot...");
        }
    }

    public void grappleTransport()
    {
        character.GetComponent<CharacterController>().enabled = false;
        character.transform.position = this.transform.position + new Vector3(0,1,0);
        character.GetComponent<CharacterController>().enabled = true;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
