using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100;


    bool isShooting = false;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        ProcessShooting();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
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


    private void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }

    private void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position;
            //Subtracting laser form target position to return vector between laser origin and target
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            //calculates rotation for laser origin to point it to the target point
            laser.transform.rotation = rotationToTarget;
            //rotate to above rotation
        }
    }
}
