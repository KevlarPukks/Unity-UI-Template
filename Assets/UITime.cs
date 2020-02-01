using UnityEngine;
using UnityEngine.Events;

public class UITime : GameUIText
{
    public static UITime uITime;
    [SerializeField] private bool shouldCountDown;
    private bool isPaused;
    public float CountDownStartTime;
    public UnityEvent onCountDownFinish;
    public override void Awake()
    {
        base.Awake();
        if (uITime == null) uITime = this;
        Name = "Time";
    }
    private void OnEnable()
    {
        Restart();
    }
    private void Update()
    {
        if (!isPaused)
        {
            if (!shouldCountDown)
            {
                SetValue(Value + Time.deltaTime * 1);
            }
            else
            {
           
                SetValue(Value - Time.deltaTime * 1);
                if(Value<= 0)
                {
                    onCountDownFinish.Invoke();
                    Stop();
                }
            }
        } 
    } 
    public void Restart()
    {
        if (shouldCountDown)
        {
            SetValue(CountDownStartTime);
            
        }
        else
        {
            SetValue(0);
        }
        Play();
    }
    public void Pause()
    {
        isPaused = true;
        SetValue(Value);
    }
    public void Stop()
    {
        isPaused = true;
        Restart();
      
    }
    public void Play()
    {
        isPaused = false;
    }
}
