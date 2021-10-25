using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBattle : UIBase
{
    private enum Texts
    {
        UnitCodeText,
        PilotNameText
    }

    private enum Buttons
    {
        UnitButton,
        PilotButton
    }

    private enum Images
    {
        FadeImage
    }

    private enum RawImages
    {
        StatusImage
    }

    private enum GameObjects
    {
        HPBar,
        ENBar
    }

    void Start()
    {
        Bind<Text>(typeof(Texts));
        Bind<Button>(typeof(Buttons));
        Bind<Image>(typeof(Images));
        Bind<RawImage>(typeof(RawImages));
        Bind<GameObject>(typeof(GameObjects));

        GameManager.Input.MouseAction += MouseAction;

        InitUI();



        GameManager.Sound.Play("FirstGundamOST/Track07GallantChar", Define.Sound.Bgm);
    }

    private void MouseAction(Define.MouseEvent evt)
    {

    }

    private void InitUI()
    {

    }


}
