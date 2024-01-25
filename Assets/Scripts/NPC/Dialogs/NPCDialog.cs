using System;
using System.IO;
using UnityEngine;
using DialogueEditor;

public class NPCDialog : MonoBehaviour
{
    static Texture2D cursorTexture = null;
    static readonly object lockObject = new();
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = new Vector2(32, 32);

    private void Awake()
    {
        lock (lockObject)
        {
            if (cursorTexture is null)
            {
                // Source : https://stackoverflow.com/questions/31186215/loading-an-image-as-texture2d
                byte[] fileData;
                string filePath = "Assets/Icons/speech-bubble.png";

                if (File.Exists(filePath))
                {
                    fileData = File.ReadAllBytes(filePath);
                    cursorTexture = new Texture2D(64, 64);
                    cursorTexture.LoadImage(fileData); //..this will auto-resize the texture dimensions.
                }
                else
                {
                    Debug.Log(filePath + " does not exist");
                }
            }
        }
    }

    protected void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    protected void OnMouseExit()
    {
        // Pass 'null' to the texture parameter to use the default system cursor.
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    protected void AddDialogCallback(Action callbackScript)
    {
        // Cursor visible on hover, to show that the NPC is interactable.
        Cursor.visible = true;

        if (!MainController.Instance.IsInConversation && Input.GetMouseButtonDown(0))
        {
            callbackScript();
        }
    }
}
