using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] GameObject[] lasers;


    bool isShooting = false;

    void Update()
    {
        ProcessShooting();
    }

    public void OnShoot(InputValue value)
    {
        isShooting = value.isPressed;
    }

    private void ProcessShooting()
    {
        foreach (GameObject weapon in lasers)
        {
            var emissionModule = weapon.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isShooting;
        }
    }
}
