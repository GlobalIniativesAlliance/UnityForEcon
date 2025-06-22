using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuInterface : MonoBehaviour
{
    [Header("UI References")]
    public Canvas canvas;
    public GameObject buttonPrefab;
    
    [Header("Menu Settings")]
    public Color backgroundColor = new Color(0.15f, 0.15f, 0.15f, 1f);
    public Color buttonColor = new Color(0.2f, 0.2f, 0.2f, 1f);
    public Color buttonHoverColor = new Color(0.3f, 0.3f, 0.3f, 1f);
    public Color textColor = Color.white;
    public Color accentColor = new Color(0.2f, 0.5f, 1f, 1f);
    
    private string[] menuOptions = {
        "Trade School - cost",
        "College",
        "Job"
    };
    
    void Start()
    {
        CreateMenuInterface();
    }
    
    void CreateMenuInterface()
    {
        // Create main background panel
        GameObject backgroundPanel = CreatePanel("BackgroundPanel", canvas.transform);
        Image bgImage = backgroundPanel.GetComponent<Image>();
        bgImage.color = backgroundColor;
        
        // Add accent border
        GameObject accentBorder = CreatePanel("AccentBorder", backgroundPanel.transform);
        RectTransform accentRect = accentBorder.GetComponent<RectTransform>();
        accentRect.anchorMin = new Vector2(1f, 0f);
        accentRect.anchorMax = new Vector2(1f, 1f);
        accentRect.offsetMin = new Vector2(-10f, 0f);
        accentRect.offsetMax = new Vector2(0f, 0f);
        Image accentImage = accentBorder.GetComponent<Image>();
        accentImage.color = accentColor;
        
        // Create content area
        GameObject contentPanel = CreatePanel("ContentPanel", backgroundPanel.transform);
        RectTransform contentRect = contentPanel.GetComponent<RectTransform>();
        contentRect.anchorMin = new Vector2(0f, 0f);
        contentRect.anchorMax = new Vector2(1f, 1f);
        contentRect.offsetMin = new Vector2(50f, 50f);
        contentRect.offsetMax = new Vector2(-50f, -50f);
        
        // Create title
        GameObject titleObj = CreateText("Title", contentPanel.transform, "Pick one of these options");
        RectTransform titleRect = titleObj.GetComponent<RectTransform>();
        titleRect.anchorMin = new Vector2(0f, 0.8f);
        titleRect.anchorMax = new Vector2(1f, 1f);
        titleRect.offsetMin = Vector2.zero;
        titleRect.offsetMax = Vector2.zero;
        
        TextMeshProUGUI titleText = titleObj.GetComponent<TextMeshProUGUI>();
        titleText.fontSize = 24f;
        titleText.fontStyle = FontStyles.Normal;
        titleText.alignment = TextAlignmentOptions.Center;
        
        // Create menu buttons
        float buttonHeight = 60f;
        float buttonSpacing = 20f;
        float startY = 0.6f;
        
        for (int i = 0; i < menuOptions.Length; i++)
        {
            GameObject button = CreateMenuButton(menuOptions[i], contentPanel.transform, i);
            RectTransform buttonRect = button.GetComponent<RectTransform>();
            
            float yPos = startY - (i * (buttonHeight + buttonSpacing) / 400f);
            buttonRect.anchorMin = new Vector2(0f, yPos - 0.08f);
            buttonRect.anchorMax = new Vector2(1f, yPos);
            buttonRect.offsetMin = Vector2.zero;
            buttonRect.offsetMax = Vector2.zero;
        }
    }
    
    GameObject CreatePanel(string name, Transform parent)
    {
        GameObject panel = new GameObject(name);
        panel.transform.SetParent(parent, false);
        
        RectTransform rect = panel.AddComponent<RectTransform>();
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.offsetMin = Vector2.zero;
        rect.offsetMax = Vector2.zero;
        
        Image image = panel.AddComponent<Image>();
        image.color = Color.clear;
        
        return panel;
    }
    
    GameObject CreateText(string name, Transform parent, string text)
    {
        GameObject textObj = new GameObject(name);
        textObj.transform.SetParent(parent, false);
        
        RectTransform rect = textObj.AddComponent<RectTransform>();
        TextMeshProUGUI textComponent = textObj.AddComponent<TextMeshProUGUI>();
        
        textComponent.text = text;
        textComponent.color = textColor;
        textComponent.fontSize = 18f;
        textComponent.alignment = TextAlignmentOptions.Left;
        
        return textObj;
    }
    
    GameObject CreateMenuButton(string text, Transform parent, int index)
    {
        GameObject buttonObj = new GameObject("MenuButton_" + index);
        buttonObj.transform.SetParent(parent, false);
        
        // Add Button component
        Button button = buttonObj.AddComponent<Button>();
        Image buttonImage = buttonObj.AddComponent<Image>();
        buttonImage.color = buttonColor;
        
        // Configure button colors
        ColorBlock colors = button.colors;
        colors.normalColor = buttonColor;
        colors.highlightedColor = buttonHoverColor;
        colors.pressedColor = new Color(0.4f, 0.4f, 0.4f, 1f);
        colors.selectedColor = buttonHoverColor;
        colors.disabledColor = new Color(0.1f, 0.1f, 0.1f, 1f);
        button.colors = colors;
        
        // Add button text
        GameObject textObj = CreateText("ButtonText", buttonObj.transform, text);
        RectTransform textRect = textObj.GetComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.offsetMin = new Vector2(20f, 0f);
        textRect.offsetMax = new Vector2(-20f, 0f);
        
        TextMeshProUGUI textComponent = textObj.GetComponent<TextMeshProUGUI>();
        textComponent.alignment = TextAlignmentOptions.Left;
        textComponent.verticalAlignment = VerticalAlignmentOptions.Middle;
        
        // Add button functionality
        button.onClick.AddListener(() => OnMenuOptionSelected(text, index));
        
        return buttonObj;
    }
    
    void OnMenuOptionSelected(string option, int index)
    {
        Debug.Log($"Selected option: {option} (Index: {index})");
        
        // Add your custom logic here
        switch (index)
        {
            case 0:
                // Trade School selected
                HandleTradeSchoolSelection();
                break;
            case 1:
                // College selected
                HandleCollegeSelection();
                break;
            case 2:
                // Job selected
                HandleJobSelection();
                break;
        }
    }
    
    void HandleTradeSchoolSelection()
    {
        Debug.Log("Trade School option selected");
        // Implement trade school logic
    }
    
    void HandleCollegeSelection()
    {
        Debug.Log("College option selected");
        // Implement college logic
    }
    
    void HandleJobSelection()
    {
        Debug.Log("Job option selected");
        // Implement job logic
    }
}