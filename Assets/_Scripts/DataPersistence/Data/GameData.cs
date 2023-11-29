using System;

[Serializable]
public class GameData 
{
    public int Money;
    public int Diamond;
    
    public int MoneyPerClick;
    public int MoneyPerSecond;

    public int TimeExit;

    public GameData(){
        this.Money = 0;
        this.Diamond = 0;
        this.MoneyPerClick = 0;
        this.MoneyPerSecond = 0;
        this.TimeExit = 0;
    }
    
}
