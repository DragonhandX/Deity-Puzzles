using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScreen : MonoBehaviour {

    public Canvas canvas;
    public GameObject startButton;

	// Use this for initialization
	void Start () {
        
	}

    private void OnMouseUpAsButton()
    {
        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.Out, "Room 1"));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
