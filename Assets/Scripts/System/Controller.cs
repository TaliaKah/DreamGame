using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoSingleton<Controller>
{
    public Camera MainCamera;
    public Transform CameraPosition;
    CharacterController m_CharacterController;

    [Header("Control Settings")]
    public float MouseSensitivity = 100.0f;
    public float PlayerSpeed = 5.0f;
    public float RunningSpeed = 7.5f;

    float m_VerticalSpeed = 0.0f;
    float m_VerticalAngle, m_HorizontalAngle;
    bool m_IsPaused;
    bool m_IsInConversation;

    void Start()
    {
        m_IsPaused = false;
        m_IsPaused = true;
        m_VerticalAngle = 0.0f;
        m_HorizontalAngle = transform.localEulerAngles.y;

        MainCamera.transform.SetParent(CameraPosition, false);
        MainCamera.transform.localPosition = Vector3.zero;
        MainCamera.transform.localRotation = Quaternion.identity;

        m_CharacterController = GetComponent<CharacterController>();
    }

    bool IsUpdatable() {
        return !m_IsPaused && !m_IsInConversation;
    }

    public void PauseFlags(bool display)
    {
        m_IsPaused = display;
        Cursor.lockState = display ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = display;
        m_IsInConversation = display;
    }

    public void PauseTheGame() {
        PauseFlags(true);
    }

    public void TogglePause() {
        PauseFlags(!m_IsPaused);
    }

    void Update()
    {
        Vector3 move = Vector3.zero;

        if (IsUpdatable())
        {
            // Move around with ZQSD
            move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            if (move.sqrMagnitude > 1.0f)
                move.Normalize();

            // float usedSpeed = m_Grounded ? actualSpeed : m_SpeedAtJump;
            bool running = Input.GetButton("Run");
            if (running) Debug.Log("Character is running");
            float actualSpeed = running ? RunningSpeed : PlayerSpeed;
            move = move * actualSpeed * Time.deltaTime;
            
            move = transform.TransformDirection(move);
            m_CharacterController.Move(move);

            // Fall down / gravity
            m_VerticalSpeed = m_VerticalSpeed - 10.0f * Time.deltaTime;
            if (m_VerticalSpeed < -10.0f)
                m_VerticalSpeed = -10.0f; // max fall speed
            var verticalMove = new Vector3(0, m_VerticalSpeed * Time.deltaTime, 0);
            var flag = m_CharacterController.Move(verticalMove);
            if ((flag & CollisionFlags.Below) != 0)
                m_VerticalSpeed = 0;

            // Turn player
            float turnPlayer = Input.GetAxis("Mouse X") * MouseSensitivity;
            m_HorizontalAngle = m_HorizontalAngle + turnPlayer;

            if (m_HorizontalAngle > 360) m_HorizontalAngle -= 360.0f;
            if (m_HorizontalAngle < 0) m_HorizontalAngle += 360.0f;

            Vector3 currentAngles = transform.localEulerAngles;
            currentAngles.y = m_HorizontalAngle;
            transform.localEulerAngles = currentAngles;

            // Camera look up/down
            var turnCam = -Input.GetAxis("Mouse Y");
            turnCam = turnCam * MouseSensitivity;
            m_VerticalAngle = Mathf.Clamp(turnCam + m_VerticalAngle, -89.0f, 89.0f);
            currentAngles = CameraPosition.transform.localEulerAngles;
            currentAngles.x = m_VerticalAngle;
            CameraPosition.transform.localEulerAngles = currentAngles;
        } else {

        }
    }
}
