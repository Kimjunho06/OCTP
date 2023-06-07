using UnityEngine;

public class SpaceshipPieceObject : MonoBehaviour {
    [SerializeField] private int index;
    [SerializeField] private SpaceshipConstruction construction;

    private void Correcting() {
        construction.isCollecting[index] = true;
    }
}
