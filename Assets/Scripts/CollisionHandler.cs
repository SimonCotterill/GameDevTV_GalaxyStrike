using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log("Hit " + other.name);
        //Or UnityEngine.Debug.Log($"Hit {other.gameObject.name}");
    }
}
