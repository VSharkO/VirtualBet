using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class sceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

    public void MakeTicket()
    {
        SceneManager.LoadScene("MakeTicket");
    }
    public void Home()
    {
        SceneManager.LoadScene("Home");
    }
    public void Result()
    {
        SceneManager.LoadScene("Result");
    }
}
