using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Controller : MonoBehaviour
{
    private static Controller instance;
    public static Controller Instance
    {
        get; private set;
    }

    public Camera MainCamera;
    public Transform CameraPosition;
    CharacterController m_CharacterController;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    [Header("Control Settings")]
    public float MouseSensitivity = 50.0f;
    public readonly float MinSensitivity = 20.0f;
    public readonly float MaxSensitivity = 100.0f;
    public float PlayerSpeed = 5.0f;
    public float RunningSpeed = 7.5f;

    float m_VerticalAngle, m_HorizontalAngle;
    bool m_IsPaused = false;
    bool m_IsInConversation = false;
    public bool IsInConversation => m_IsInConversation;


    void Awake()
    {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.LogError("Creation failed: Controller already exists");
        }
    }

    void Start()
    {
        SetPauseFlags();
        m_VerticalAngle = 0.0f;
        m_HorizontalAngle = transform.localEulerAngles.y;

        MainCamera.transform.SetParent(CameraPosition, false);
        MainCamera.transform.localPosition = Vector3.zero;
        MainCamera.transform.localRotation = Quaternion.identity;

        m_CharacterController = GetComponent<CharacterController>();
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }



    bool IsUpdatable()
    {
        return !m_IsPaused && !m_IsInConversation;
    }

    public void SetPauseFlags()
    {
        bool display = m_IsPaused | m_IsInConversation;
        Cursor.lockState = display ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = display;
    }

    public void SetConversationMode(bool value) {
        m_IsInConversation = value;
        SetPauseFlags();
    }

    public void PauseTheGame()
    {
        m_IsPaused = true;
        SetPauseFlags();
    }

    public void TogglePause()
    {
        m_IsPaused = !m_IsPaused;
        SetPauseFlags();
    }

    public void ResumeTheGame()
    {
        m_IsPaused = false;
        SetPauseFlags();
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
            navMeshAgent.speed = running ? RunningSpeed : PlayerSpeed;
            move = transform.TransformDirection(move);

            navMeshAgent.Move(move * Time.deltaTime * navMeshAgent.speed);

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

            if (Input.GetButtonDown("Cancel"))
            {
                PauseTheGame();
                SceneLoaderAsync.Instance.LoadScene("Game Menu", LoadSceneMode.Additive);
            }

            Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Vector2 screenCenterFloored = new Vector2((float) Math.Floor(screenCenter.x), (float) Math.Floor(Screen.height / 2f));
            if (new Vector2(Input.mousePosition.x, Input.mousePosition.y) != screenCenterFloored) {
                Mouse.current.WarpCursorPosition(screenCenter);
            }
        }
    }
}
