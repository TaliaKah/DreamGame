using System;
using UnityEngine;
using DialogueEditor;

public class NPCDialog : MonoBehaviour
{
    public Texture2D cursorTexture;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    protected void OnMouseEnter() {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    protected void OnMouseExit()
    {
        // Pass 'null' to the texture parameter to use the default system cursor.
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    protected virtual void MouseOver(Action callbackScript) {
        // Cursor visible on hover, to show that the NPC is interactable.
        Cursor.visible = true;

        if (!Controller.Instance.IsInConversation && Input.GetMouseButtonDown(0)) {
            callbackScript();
        }
    }
}
