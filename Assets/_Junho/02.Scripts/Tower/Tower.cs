using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IInteraction
{
    public void Interaction()
    {
        print("��ȣ �ۿ�� ���� �� �Լ��Դϴ�.");
    }

    public void View()
    {
        print("��ȣ �ۿ� �� UI �����ֱ�");
    }
}
