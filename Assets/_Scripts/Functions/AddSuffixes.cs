using UnityEngine;

namespace NeverMindEver.Functions{
    public class AddSuffixes 
    {
        public string DivisionMoney(double value,int i=0){

            if(value<1000)
                return SetSuffixesMoney(value,i);
            else{
                value /=1000;
                i++;
                return DivisionMoney(value,i);
            }
        }

        private string SetSuffixesMoney(double value,int i){
            switch(i){
                case 0 :
                    return value.ToString();
                case 1:
                    return Mathf.Round((float)value).ToString() + "K";
                case 2:
                    return Mathf.Round((float)value).ToString() + "M";
                case 3:
                    return Mathf.Round((float)value).ToString() + "B";
                case 4:
                    return Mathf.Round((float)value).ToString() + "T";
                case 5:
                    return Mathf.Round((float)value).ToString() + "Qa";
                case 6:
                    return Mathf.Round((float)value).ToString() + "Sx";
                case 7:
                    return Mathf.Round((float)value).ToString() + "Sp";
                case 8:
                    return Mathf.Round((float)value).ToString() + "No";
                case 9:
                    return Mathf.Round((float)value).ToString() + "Dc";
                case 10:
                    return Mathf.Round((float)value).ToString() + "Ud";
                case 11:
                    return Mathf.Round((float)value).ToString() + "Dd";
                case 12:
                    return Mathf.Round((float)value).ToString() + "Td";
                default:
                    return "Infinity???";
            }
        }
    }
}