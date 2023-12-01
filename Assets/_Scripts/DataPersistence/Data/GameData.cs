using System;

[Serializable]
public class GameData 
{
    public double Money;
    public int Diamond;
    
    public double MoneyPerClick;
    public double MoneyPerSecond;

    public double TimeExit;

    public GameData(){
        this.Money = 0;
        this.Diamond = 0;
        this.MoneyPerClick =1;
        this.MoneyPerSecond = 1;
        this.TimeExit = 0;
    }
    
}
