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

namespace Fathalfath30.Scene.MainMenu {
    public class MainMenu : MonoBehaviour {
        [SerializeField] private Button ButtonStartGame;
        [SerializeField] private Button ButtonExitGame;
        [SerializeField] private Canvas CanvasFade;
        [SerializeField] private float FadeInterval = 2.5f;
        private Image FadeImage;
        private GameObject ObjCanvasFade;
        private AsyncOperation asyncOps;

        private IEnumerator Mulai_permainan() {
            FadeImage.CrossFadeAlpha (0f, FadeInterval, false);
            ObjCanvasFade.SetActive (true);

            FadeImage.CrossFadeAlpha (1f, FadeInterval, true);
            yield return new WaitForSeconds (FadeInterval + 1f);

            SceneManager.LoadScene ("Level_0", LoadSceneMode.Single);
        }

        private void initUI() {
            FadeImage.CrossFadeAlpha (0f, 0f, false);
            ObjCanvasFade.SetActive (false);
        }
        
        private void initButtonFunc () {
            ButtonStartGame.onClick.AddListener (() => {
                // Memberika fungsi click pada tombol "start"
                StartCoroutine(Mulai_permainan ());
            });

            ButtonExitGame.onClick.AddListener (() => {
                // Memberika fungsi click pada tombol "start"
                Application.Quit ();
            });
        }

        private void Start () {
            FadeImage = CanvasFade.GetComponent<Image> ();
            ObjCanvasFade = CanvasFade.gameObject;

            initUI ();
            initButtonFunc ();
        }
    }
}