using System;

[Serializable]
public class GameData 
{
    public int Money;
    public int Diamond;
    
    public int MoneyPerClick;
    public int MoneyPerSecond;

    public double TimeExit;

    public GameData(){
        this.Money = 0;
        this.Diamond = 0;
        this.MoneyPerClick =1;
        this.MoneyPerSecond = 1;
        this.TimeExit = 0;
    }
    
}
