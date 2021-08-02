using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISelection : UIBase
{
    private enum Buttons
    {
        BrightButton,
        RhysButton,
        DominickButton,
        LeonButton
    }

    private enum Texts
    {
        BrightText,
        RhysText,
        DominickText,
        LeonText,
    }

    private enum GameObjects
    {
        BrightPanel,
        RhysPanel,
        DominickPanel,
        LeonPanel
    }

    private enum Images
    {
        FadeImage
    }

    private Image fadeImage;

    void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        fadeImage = GetImage((int)Images.FadeImage);
    }

    void Update()
    {
        
    }
}
