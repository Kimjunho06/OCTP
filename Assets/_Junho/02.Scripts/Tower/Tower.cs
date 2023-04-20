using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IInteraction
{
    public void Interaction()
    {
        print("상호 작용시 실행 될 함수입니다.");
    }

    public void View()
    {
        print("상호 작용 전 UI 보여주기");
    }
}
