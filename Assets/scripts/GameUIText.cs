using UnityEngine;
using UnityEngine.UI;

public class GameUIText : MonoBehaviour
{
  protected string Name;
  protected Text TextComponent;
   [HideInInspector] public float Value;

    public virtual void Awake()
    {
        TextComponent = GetComponentInChildren<Text>();
    }
    public void SetValue(float value)
    {
        Value = value;
        SetText();
    }

    public void SetText()
    {
        TextComponent.text = $"{Name}:\n{Value.ToString("F0")}";
    }
}
