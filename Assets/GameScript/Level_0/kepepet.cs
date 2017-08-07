//
//    ______    _   _           _  __      _   _     ____   ___  
//   |  ____|  | | | |         | |/ _|    | | | |   |___ \ / _ \ 
//   | |__ __ _| |_| |__   __ _| | |_ __ _| |_| |__   __) | | | |
//   |  __/ _` | __| '_ \ / _` | |  _/ _` | __| '_ \ |__ <| | | |
//   | | | (_| | |_| | | | (_| | | || (_| | |_| | | |___) | |_| |
//   |_|  \__,_|\__|_| |_|\__,_|_|_| \__,_|\__|_| |_|____/ \___/ 
// 
// Licensed under GNU General Public License v3.0
// http://www.gnu.org/licenses/gpl-3.0.txt
// Written by Fathalfath30. Email : fathalfath30@gmail.com
// Follow me on GithHub : https://github.com/Fathalfath30
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Fathalfath30.Scene.Level_0;

public class kepepet : MonoBehaviour {

    public GameObject object_buku;
    public Canvas canvas_kepepet;
    public GameObject lariii;

    // Use this for initialization
    void Start () {
        canvas_kepepet.gameObject.SetActive (false);
        canvas_kepepet.GetComponent<Image> ().CrossFadeAlpha (0f, 0f, false);
	}


    private IEnumerator gover () {
        canvas_kepepet.gameObject.SetActive (true);
        canvas_kepepet.GetComponent<Image> ().CrossFadeAlpha (1f, 1.5f, false);
        yield return new WaitForSeconds (4f);
        
        SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        yield return null;
    }

    // Update is called once per frame
    void Update () {
        if ( Vector3.Distance (transform.position, object_buku.transform.position) <= 3f) {
            lariii.SetActive (false);
            StartCoroutine (gover ());
        } 

	}
}
