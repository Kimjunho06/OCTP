using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core{

public class Define 
{
    private Camera mainCamera = null;
    public Camera MainCamera {
        get{
            if(mainCamera == null) mainCamera = Camera.main;
            return mainCamera;
        }
    }

}
}
