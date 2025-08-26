using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{

    [SerializeField] GameObject destroyedVFX;
    [SerializeField] int hitPoints = 3;
    [SerializeField] int pointsValue = 10;

    Scoreboard scoreboard;

    void Start ()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

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
            scoreboard.ChangeScore(pointsValue);
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);
            //Quaternion.identity just means no rotation
            Destroy(this.gameObject);
        }
    }
}
