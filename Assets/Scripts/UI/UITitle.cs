using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UITitle : MonoBehaviour
{
    private Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        

        quitButton = root.Q<Button>("QuitButton");
        quitButton.clicked += QuitButtonClicked;
    }

    void QuitButtonClicked()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
