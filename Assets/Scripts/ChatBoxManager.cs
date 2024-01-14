using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatboxManager : MonoBehaviour
{
    public TMP_InputField playerNameInput;
    public TMP_InputField messageInput;
    public TMP_Text chatText;
    public Scrollbar chatScrollbar;
    public RectTransform contentBox;

    public Color playerTextColor = Color.white;
    public Color timestampColor = Color.gray;

    public float playerTextSize = 14f;
    public float timestampTextSize = 12f;

    private List<string> chatHistory = new List<string>();
    private const int MaxChatHistoryLines = 20;

    private void Start()
    {
        messageInput.onEndEdit.AddListener(SendChatMessage);
    }

    private void SendChatMessage(string message)
    {
        if (!string.IsNullOrEmpty(message))
        {
            string playerName = string.IsNullOrEmpty(playerNameInput.text) ? "Player" : playerNameInput.text;
            string playerMessage = $"<color=#{ColorUtility.ToHtmlStringRGB(playerTextColor)}><size={playerTextSize}><b>{playerName}:</b> {message}</size></color>";
            string timestamp = $"<color=#{ColorUtility.ToHtmlStringRGB(timestampColor)}><size={timestampTextSize}>{DateTime.Now.ToString("HH:mm:ss")}</size></color>";
            string formattedMessage = $"{playerMessage} - {timestamp}\n";

            chatHistory.Add(formattedMessage);
            ShowChatHistory();
            messageInput.text = "";
        }
    }

    private void ShowChatHistory()
    {
        chatText.text = string.Join("", chatHistory);
        AdjustContentSize();
        StartCoroutine(ScrollToBottom());
    }

    private void AdjustContentSize()
    {
        float preferredHeight = chatText.preferredHeight;
        contentBox.sizeDelta = new Vector2(contentBox.sizeDelta.x, preferredHeight);
    }

    private IEnumerator ScrollToBottom()
    {
        yield return null;
        chatScrollbar.value = 0f;
        yield return null;
        chatScrollbar.value = 0f;
    }
}
