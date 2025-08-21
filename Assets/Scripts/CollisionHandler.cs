using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] GameObject destroyedVFX;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);

        UnityEngine.Debug.Log("Hit " + other.name);
        //Or UnityEngine.Debug.Log($"Hit {other.gameObject.name}");
    }
}
