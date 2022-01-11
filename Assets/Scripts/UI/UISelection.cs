using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISelection : UIBase
{
    private enum Buttons
    {
        BrightButton,
        RhysButton,
        DominickButton,
        LeonButton,
        StartButton,
        BackToMainButton
    }

    private enum GameObjects
    {
        BrightPanel = 0,
        RhysPanel,
        DominickPanel,
        LeonPanel,
        BrightImage,
        RhysImage,
        DominickImage,
        LeonImage,
        MaxCount
    }

    private enum Texts
    {
        BrightText,
        RhysText,
        DominickText,
        LeonText,
        BrightName,
        BrightAffiliation,
        BrightRank,
        BrightBirth,
        BrightHeight,
        RhysName,
        RhysAffiliation,
        RhysRank,
        RhysBirth,
        RhysHeight,
        DominickName,
        DominickAffiliation,
        DominickRank,
        DominickBirth,
        DominickHeight,
        LeonName,
        LeonAffiliation,
        LeonRank,
        LeonBirth,
        LeonHeight,
        MaxCount
    }

    private enum Images
    {
        FadeImage
    }

    private enum NextScene
    {
        Main,
        Dialogue
    }
    NextScene next = NextScene.Dialogue;

    private Image fadeImage;
    private bool fadeOut = false;
    private Define.Character mainChar = Define.Character.BrightNoa;

    void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));

        fadeImage = GetImage((int)Images.FadeImage);
        StartCoroutine(FadeInCoroutine());

        if (GameManager.Data.Environment.Language == Define.Language.Korean)
        {
            GetText((int)Texts.BrightText).text = "브라이트 노아";
            GetText((int)Texts.BrightName).text = "이름: 브라이트 노아";
            GetText((int)Texts.BrightAffiliation).text = "소속: 지구연방군";
            GetText((int)Texts.BrightRank).text = "계급: 사관생도";
            GetText((int)Texts.BrightBirth).text = "생년: 0060 (U.C.)";
            GetText((int)Texts.BrightHeight).text = "신장: 175cm";

            GetText((int)Texts.RhysText).text = "리스 제온";
            GetText((int)Texts.RhysName).text = "이름: 리스 제온";
            GetText((int)Texts.RhysAffiliation).text = "소속: 지구연방군";
            GetText((int)Texts.RhysRank).text = "계급: 사관생도";
            GetText((int)Texts.RhysBirth).text = "생년: 0060 (U.C.)";
            GetText((int)Texts.RhysHeight).text = "신장: 169cm";

            GetText((int)Texts.DominickText).text = "도미닉 윌리엄";
            GetText((int)Texts.DominickName).text = "이름: 도미닉 윌리엄";
            GetText((int)Texts.DominickAffiliation).text = "소속: 지구연방군";
            GetText((int)Texts.DominickRank).text = "계급: 소위";
            GetText((int)Texts.DominickBirth).text = "생년: 0057 (U.C.)";
            GetText((int)Texts.DominickHeight).text = "신장: 187cm";

            GetText((int)Texts.LeonText).text = "레온 마세나스";
            GetText((int)Texts.LeonName).text = "이름: 레온 마세나스";
            GetText((int)Texts.LeonAffiliation).text = "소속: 지구연방군";
            GetText((int)Texts.LeonRank).text = "계급: 소위";
            GetText((int)Texts.LeonBirth).text = "생년: 0058 (U.C.)";
            GetText((int)Texts.LeonHeight).text = "신장: 183cm";
        }
        else if (GameManager.Data.Environment.Language == Define.Language.Japanese)
        {
            GetText((int)Texts.BrightText).text = "ブライト ノア";
            GetText((int)Texts.BrightName).text = "名前: ブライト ノア";
            GetText((int)Texts.BrightAffiliation).text = "所属: 地球連邦軍";
            GetText((int)Texts.BrightRank).text = "階級: 士官生徒";
            GetText((int)Texts.BrightBirth).text = "生年: 0060 (U.C.)";
            GetText((int)Texts.BrightHeight).text = "身長: 175cm";

            GetText((int)Texts.RhysText).text = "リース ゼオン";
            GetText((int)Texts.RhysName).text = "名前: リース ゼオン";
            GetText((int)Texts.RhysAffiliation).text = "所属: 地球連邦軍";
            GetText((int)Texts.RhysRank).text = "階級: 士官生徒";
            GetText((int)Texts.RhysBirth).text = "生年: 0060 (U.C.)";
            GetText((int)Texts.RhysHeight).text = "身長: 169cm";

            GetText((int)Texts.DominickText).text = "ドミニク ウィリアム";
            GetText((int)Texts.DominickName).text = "名前: ドミニク ウィリアム";
            GetText((int)Texts.DominickAffiliation).text = "所属: 地球連邦軍";
            GetText((int)Texts.DominickRank).text = "階級: 少尉";
            GetText((int)Texts.DominickBirth).text = "生年: 0057 (U.C.)";
            GetText((int)Texts.DominickHeight).text = "身長: 187cm";

            GetText((int)Texts.LeonText).text = "レオン マセナス";
            GetText((int)Texts.LeonName).text = "名前: レオン マセナス";
            GetText((int)Texts.LeonAffiliation).text = "所属: 地球連邦軍";
            GetText((int)Texts.LeonRank).text = "階級: 少尉";
            GetText((int)Texts.LeonBirth).text = "生年: 0058 (U.C.)";
            GetText((int)Texts.LeonHeight).text = "身長: 183cm";

            //SetJapaneseFont();
        }

        SetMainCharacter("Bright");

        GameObject brightButton = GetButton((int)Buttons.BrightButton).gameObject;
        brightButton.BindEvent(OnHover, Define.UIEvent.Hover);
        brightButton.BindEvent(OnClickBright);

        GameObject rhysButton = GetButton((int)Buttons.RhysButton).gameObject;
        rhysButton.BindEvent(OnHover, Define.UIEvent.Hover);
        rhysButton.BindEvent(OnClickRhys);

        GameObject dominickButton = GetButton((int)Buttons.DominickButton).gameObject;
        dominickButton.BindEvent(OnHover, Define.UIEvent.Hover);
        dominickButton.BindEvent(OnClickDominick);

        GameObject leonButton = GetButton((int)Buttons.LeonButton).gameObject;
        leonButton.BindEvent(OnHover, Define.UIEvent.Hover);
        leonButton.BindEvent(OnClickLeon);

        GameObject startButton = GetButton((int)Buttons.StartButton).gameObject;
        startButton.BindEvent(OnHover, Define.UIEvent.Hover);
        startButton.BindEvent(OnClickStart);

        GameObject backButrton = GetButton((int)Buttons.BackToMainButton).gameObject;
        backButrton.BindEvent(OnHover, Define.UIEvent.Hover);
        backButrton.BindEvent(OnClickBack);
    }

    private void SetJapaneseFont()
    {
        for (int i = 0; i < (int)Texts.MaxCount; i++)
        {
            GetText(i).font = GameManager.Resource.Load<Font>("Fonts/PixelMplus10");
            if (GetText(i).fontSize == 20)
                GetText(i).fontSize = 15;
        }
    }

    private void OnHover(PointerEventData data)
    {
        GameManager.Sound.Play("Effect/Hover");
    }

    private void OnClickBright(PointerEventData data)
    {
        GameManager.Sound.Play("Effect/Select");
        mainChar = Define.Character.BrightNoa;
        SetMainCharacter("Bright");
    }

    private void OnClickRhys(PointerEventData data)
    {
        GameManager.Sound.Play("Effect/Select");
        mainChar = Define.Character.RhysJeon;
        SetMainCharacter("Rhys");
    }

    private void OnClickDominick(PointerEventData data)
    {
        GameManager.Sound.Play("Effect/Select");
        mainChar = Define.Character.DominickWilliam;
        SetMainCharacter("Dominick");
    }

    private void OnClickLeon(PointerEventData data)
    {
        GameManager.Sound.Play("Effect/Select");
        mainChar = Define.Character.LeonMarcenas;
        SetMainCharacter("Leon");
    }

    private void OnClickBack(PointerEventData data)
    {
        GameManager.Sound.Play("Effect/Select");
        next = NextScene.Main;
        StartCoroutine(FadeOutCoroutine());
    }

    private void OnClickStart(PointerEventData data)
    {
        GameManager.Sound.Play("Effect/Select");
        next = NextScene.Dialogue;
        GameManager.Data.Common.MainCharacter = mainChar;
        GameManager.Data.Common.War = Define.War.TheOneYearWar;

        if (mainChar == Define.Character.BrightNoa || mainChar == Define.Character.RhysJeon)
        {
            GameManager.Data.Characters.Add(mainChar, new Character(
                    mainChar, Define.Affiliation.EFSF, Define.Rank.WarrantOfficer, 0, 0));
            GameManager.Data.Common.NextScene = Define.Scene.TemRayRoom;
        }
        else
        {
            GameManager.Data.Characters.Add(mainChar, new Character(
                    mainChar, Define.Affiliation.EFSF, Define.Rank.PettyOfficer1stClass, 0, 0));
            GameManager.Data.Common.NextScene = Define.Scene.GundamFactory;
        }

        StartCoroutine(FadeOutCoroutine());
    }

    private void SetMainCharacter(string name)
    {
        for (int i = 0; i < (int)GameObjects.MaxCount; i++)
        {
            if (GetGameObject(i).name.Contains(name))
                GetGameObject(i).SetActive(true);
            else
                GetGameObject(i).SetActive(false);
        }
    }

    void Update()
    {
        if (fadeOut)
        {
            GameManager.Clear();

            switch (next)
            {
                case NextScene.Main:
                    SceneManager.LoadScene("Main");
                    break;
                case NextScene.Dialogue:
                    SceneManager.LoadScene("Dialogue");
                    break;
            }
        }
    }

    IEnumerator FadeInCoroutine()
    {
        for (float t = 0.0f; t <= 1.0f; t += 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
            fadeImage.color = Color.Lerp(fadeImage.color, new Color(0, 0, 0, 0), t);
        }
    }

    IEnumerator FadeOutCoroutine()
    {
        for (float t = 0.0f; t <= 1.0f; t += 0.01f)
        {
            yield return new WaitForSeconds(0.01f);
            fadeImage.color = Color.Lerp(fadeImage.color, new Color(0, 0, 0, 1), t);

            if (t >= 0.50f)
                fadeOut = true;
        }
    }
}
