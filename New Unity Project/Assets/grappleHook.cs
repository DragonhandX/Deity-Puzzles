using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grappleHook : MonoBehaviour {

    public GameObject character;
    public float birthTime;
    public float lifeTime;
    Vector3 pos;
    Vector3 destPos;
    public float speed = 1.0F;
    public bool transporting = false;
    public static int grappleID = 0;
    public bool hit = false;


    private void Awake()
    {
        character = GameObject.Find("FPSController");
        grappleID++;
    }



    private void OnCollisionEnter(Collision collision)
    {

        GameObject collide = collision.gameObject;
        if (!hit)
        {
            if (collide.tag == "grappleSpot")
            {
                grappleTransport();
                //Destroy(this.gameObject);
                Debug.Log(grappleID + " grapple hook hit a grapple spot..." + collide.name);
            }
            else
            {
                Destroy(this.gameObject);
                Debug.Log(grappleID + " grapple hook did not hit a grapple spot..." + collide.name);
            }
            hit = true;
        }

        
    }

    public void grappleTransport()
    {
        //character.GetComponent<CharacterController>().enabled = false;
        pos = character.transform.position;
        destPos = this.transform.position + new Vector3(0, 1, 0);
        transporting = true;
        //character.transform.position = destPos;
        /*while (pos != destPos)
        {
            transporting = true;
        }*/
        //character.GetComponent<CharacterController>().enabled = true;
    }

    // Use this for initialization
    void Start () {
        birthTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if (transporting == true)
        {
            StartCoroutine("Moving");
            character.transform.position = destPos;
            Debug.Log(grappleID+" this is getting read");
            Destroy(this.gameObject);
        }
        
        

        /*if (transporting == true)
        {
            float journeyLength = Vector3.Distance(pos, destPos);
            float startTime = Time.time;
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            character.transform.position = Vector3.Lerp(pos, destPos, fracJourney);
            if (pos == destPos)
            {
                transporting = false;
                character.GetComponent<CharacterController>().enabled = true;
            }
        }*/
    }

    IEnumerator Moving()
    {
        float journeyLength = Vector3.Distance(pos, destPos);
        float startTime = Time.time;
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        character.transform.position = Vector3.Lerp(pos, destPos, fracJourney);
        if (pos == destPos)
        {
            transporting = false;
            character.GetComponent<CharacterController>().enabled = true;
        }
        yield return null;
    }
}
