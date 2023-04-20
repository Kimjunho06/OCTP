using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core{

public class Define 
{
    private static Camera mainCamera = null;
    public static Camera MainCamera {
        get{
            if(mainCamera == null) mainCamera = Camera.main;
            return mainCamera;
        }
    }

}
}
