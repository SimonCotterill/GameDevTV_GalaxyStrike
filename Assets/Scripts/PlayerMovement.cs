using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 100f;
    [SerializeField] float xClampRange = 30f;
    [SerializeField] float yClampRange = 15f;

    [SerializeField] float pitchFactor = 15f;
    [SerializeField] float rollFactor = 10f;
    [SerializeField] float rotationSpeed = 8f;

    Vector2 movement;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    public void OnMove(InputValue value) {
        movement = value.Get<Vector2>();
    }

    private void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);

        float yOffset = movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange*3);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }


    private void ProcessRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(-pitchFactor * movement.y, 0f, -rollFactor * movement.x);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
