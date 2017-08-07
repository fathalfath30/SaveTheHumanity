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
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

namespace Fathalfath30.Scene.Level_0 {
    public class Chasing : MonoBehaviour{
        [SerializeField] private Transform target;
        [SerializeField] private Animator anim;
        [SerializeField] private Canvas GameOver;
        [SerializeField] private AudioSource asource;
        [SerializeField] private FirstPersonController FpsController;

        private GameObject objGameOver;
        private NavMeshAgent myAgent;
        private float MaxDistance = 2.5f;
        
        public void Start () {
            asource.playOnAwake = false;
            asource.loop = false;
            myAgent = GetComponent<NavMeshAgent> ();
            objGameOver = GameOver.gameObject;
            objGameOver.SetActive (false);
            objGameOver.GetComponent<Image> ().CrossFadeAlpha (0f, 0f, false);
        }
        private IEnumerator gover() {
            objGameOver.GetComponent<Image> ().CrossFadeAlpha (1f, 1.5f, false);
            if (!asource.isPlaying)
                asource.PlayOneShot (asource.clip);
            // FpsController.gameObject.SetActive (false);
            yield return new WaitForSeconds (4f);
            SceneManager.LoadScene ("MainMenu", LoadSceneMode.Single);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            yield return null;
        }

        public void chaseTarget () {
            float distanceFromT= Vector3.Distance (target.position, transform.position);

            if ( ( distanceFromT > MaxDistance ) && ( distanceFromT < 10f)) {
                myAgent.SetDestination (target.position);

            } else if ( distanceFromT <= 2.5f ) {
                objGameOver.SetActive (true);
                // FpsController.gameObject.SetActive (false);
                StartCoroutine(gover ());
            }
        }
    
        public void Update () {
            chaseTarget ();
        }
    }
}