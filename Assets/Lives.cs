using UnityEngine.Events;

public class Lives : GameUIText
{
    public static Lives lives;
    public float startingLives = 3;
    public UnityEvent onNoLivesLeft;
    public override void Awake()
    {
        base.Awake();
        if (lives == null) lives = this;
        Name = "Lives";
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        SetValue(startingLives);
    }
    public void SetStartingLives(float amount)
    {
        startingLives = amount;
    }
    public void TakeLife(float amount)
    {
        SetValue(Value-amount);
        if (Value < 1)
        {
            onNoLivesLeft.Invoke();
        }
    }
    public void ResetLives()
    {
        SetValue(startingLives);
    }
    public void Add(float amount)
    {
        SetValue(Value + amount);
        if (Value >= startingLives) SetValue(startingLives);
    }
}
