public class Score : GameUIText
{
   public static Score score;
    public override void Awake()
    {
        base.Awake();
        if (score == null) score = this;
        Name = "Score";
    }
    public void Add(float amount)
    {
        
        SetValue(Value + amount);
       
    }
    public void Take(float amount)
    {
        SetValue(Value-amount);
      
    }
    public void Reset()
    {
        SetValue(0);
    }
}
