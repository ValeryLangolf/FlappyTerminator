using System;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public event Action JumpButtonPressed;
    public event Action ShotButtonPressed;

    private readonly KeyCode _jump = KeyCode.Space;
    private readonly KeyCode _shot = KeyCode.Mouse0;

    private void Update()
    {
        if(Input.GetKeyDown(_jump))
        {
            JumpButtonPressed?.Invoke();
        }

        if (Input.GetKeyDown(_shot))
        {
            ShotButtonPressed?.Invoke();
        }
    }
}