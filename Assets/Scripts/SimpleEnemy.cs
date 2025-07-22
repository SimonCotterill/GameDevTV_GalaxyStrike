using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{

    [SerializeField] GameObject destroyedVFX;
    
    private void OnParticleCollision(GameObject other)
    {
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
            //Quaternion.identity just means no rotation
        Destroy(this.gameObject);
    }
}
