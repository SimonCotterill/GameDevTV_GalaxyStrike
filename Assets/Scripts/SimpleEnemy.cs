using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{

    [SerializeField] GameObject destroyedVFX;
    [SerializeField] int hitPoints = 3;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        //or hitpoints--;
        //or change '1' to be a variable 'damage'

        if (hitPoints <= 0)
        {
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);
            //Quaternion.identity just means no rotation
            Destroy(this.gameObject);
        }
    }
}
