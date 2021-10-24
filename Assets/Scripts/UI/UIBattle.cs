using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBattle : UIBase
{
    void Start()
    {
        GameManager.Sound.Play("FirstGundamOST/Track07GallantChar", Define.Sound.Bgm);
    }
}
