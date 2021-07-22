using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    public class ButtonClick : MonoBehaviour
    {
        public void StartGame()
        {
            Debug.Log("start");
        }

        public void LoadGame()
        {
            Debug.Log("load");
        }

        public void SetOption()
        {
            Debug.Log("option");
        }

        public void QuitGame()
        {
            Debug.Log("quit");
            Application.Quit();
        }
    }
}
