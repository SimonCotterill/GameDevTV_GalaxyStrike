using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] GameObject destroyedVFX;

    GameSceneManager gameSceneManager;

    private void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }

    private void OnTriggerEnter(Collider other)
    {

        gameSceneManager.ReloadLevel();
        
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);

        UnityEngine.Debug.Log("Hit " + other.name);
        //Or UnityEngine.Debug.Log($"Hit {other.gameObject.name}");
    }
}
