using UnityEngine;

public class GameManager : MonoBehaviour {
    private void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        CursorVisible();
    }

    private void CursorVisible() {
        if (Input.GetKeyDown(KeyCode.C)) {
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}
