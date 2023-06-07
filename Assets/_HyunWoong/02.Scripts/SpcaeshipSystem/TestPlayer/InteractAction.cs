using UnityEngine;

public class InteractAction : MonoBehaviour {
    [SerializeField] private float _radius = 0.1f, _maxDistance = 0f;
    [SerializeField] private LayerMask _layer;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Scanning();
        }
    }

    private void Scanning() {
        Collider[] col = Physics.OverlapSphere(transform.position, _radius, _layer);
        if (col != null && col[0].transform.TryGetComponent<IInteractable>(out IInteractable I)) {
            print("isScanning");
            I.Interact();
        }
        else {
            print("is Not Scanning!");
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
