using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsBonus : MonoBehaviour
{
    public TMP_InputField inputField;
    private int intValue = 10; 

    void Start()
    {      
        inputField.onValueChanged.AddListener(OnInputFieldValueChanged);
    }

    void OnInputFieldValueChanged(string newValue)
    {
        
        if (int.TryParse(newValue, out intValue))
        {          
            Debug.Log("Integer Value: " + intValue);
        }
        else
        {          
            Debug.LogWarning("Failed to convert text to integer.");
        }
    }

    public TMP_Text Bonus;
    public TMP_Text Skill1;
    public TMP_Text Skill2;
    public TMP_Text Skill3;
    public TMP_Text Skill4;
    public TMP_Text Skill5;
    public TMP_Text Save;
   



    void Update()
    {
        if (intValue == 1) 
        {
            Bonus.text = ("-5");
            Skill1.text = ("-5");
            Skill2.text = ("-5");
            Skill3.text = ("-5");
            Skill4.text = ("-5");
            Skill5.text = ("-5");
            Skill5.text = ("-5");
        } if (intValue == 2) 
        {
            Bonus.text = ("-4");
            Skill1.text = ("-4");
            Skill2.text = ("-4");
            Skill3.text = ("-4");
            Skill4.text = ("-4");
            Save.text = ("-4");
        } if (intValue == 3) 
        {
            Bonus.text = ("-4");
            Skill1.text = ("-4");
            Skill2.text = ("-4");
            Skill3.text = ("-4");
            Skill4.text = ("-4");
            Skill5.text = ("-4");
            Save.text = ("-4");
        } if (intValue == 4) 
        {
            Bonus.text = ("-3");
            Skill1.text = ("-3");
            Skill2.text = ("-3");
            Skill3.text = ("-3");
            Skill4.text = ("-3");
            Skill5.text = ("-3");
            Save.text = ("-3");
        } if (intValue == 5)
        {
            Bonus.text = ("-3");
            Skill1.text = ("-3");
            Skill2.text = ("-3");
            Skill3.text = ("-3");
            Skill4.text = ("-3");
            Skill5.text = ("-3");
            Save.text = ("-3");
        } if (intValue == 6) 
        {
            Bonus.text = ("-2");
            Skill1.text = ("-2");
            Skill2.text = ("-2");
            Skill3.text = ("-2");
            Skill4.text = ("-2");
            Skill5.text = ("-2");
            Save.text = ("-2");
        } if (intValue == 7)
        {
            Bonus.text = ("-2");
            Skill1.text = ("-2");
            Skill2.text = ("-2");
            Skill3.text = ("-2");
            Skill4.text = ("-2");
            Skill5.text = ("-2");
            Save.text = ("-2");
        } if (intValue == 8) 
        {
            Bonus.text = ("-1");
            Skill1.text = ("-1");
            Skill2.text = ("-1");
            Skill3.text = ("-1");
            Skill4.text = ("-1");
            Skill5.text = ("-1");
            Save.text = ("-1");
        } if (intValue == 9) 
        {
            Bonus.text = ("-1");
            Skill1.text = ("-1");
            Skill2.text = ("-1");
            Skill3.text = ("-1");
            Skill4.text = ("-1");
            Skill5.text = ("-1");
            Save.text = ("-1");
        } if (intValue == 10) 
        {
            Bonus.text = ("+0");
            Skill1.text = ("+0");
            Skill2.text = ("+0");
            Skill3.text = ("+0");
            Skill4.text = ("+0");
            Skill5.text = ("+0");
            Save.text = ("+0");
        } if (intValue == 11) 
        {
            Bonus.text = ("+0");
            Skill1.text = ("+0");
            Skill2.text = ("+0");
            Skill3.text = ("+0");
            Skill4.text = ("+0");
            Skill5.text = ("+0");
            Save.text = ("+0");
        } if (intValue == 12) 
        {
            Bonus.text = ("+1");
            Skill1.text = ("+1");
            Skill2.text = ("+1");
            Skill3.text = ("+1");
            Skill4.text = ("+1");
            Skill5.text = ("+1");
            Save.text = ("+1");
        } if (intValue == 13) 
        {
            Bonus.text = ("+1");
            Skill1.text = ("+1");
            Skill2.text = ("+1");
            Skill3.text = ("+1");
            Skill4.text = ("+1");
            Skill5.text = ("+1");
            Save.text = ("+1");
        } if (intValue == 14) 
        {
            Bonus.text = ("+2");
            Skill1.text = ("+2");
            Skill2.text = ("+2");
            Skill3.text = ("+2");
            Skill4.text = ("+2");
            Skill5.text = ("+2");
            Save.text = ("+2");
        } if (intValue == 15) 
        {
            Bonus.text = ("+2");
            Skill1.text = ("+2");
            Skill2.text = ("+2");
            Skill3.text = ("+2");
            Skill4.text = ("+2");
            Skill5.text = ("+2");
            Save.text = ("+2");
        } if (intValue == 16) 
        {
            Bonus.text = ("+3");
            Skill1.text = ("+3");
            Skill2.text = ("+3");
            Skill3.text = ("+3");
            Skill4.text = ("+3");
            Skill5.text = ("+3");
            Save.text = ("+3");
        } if (intValue == 17) 
        {
            Bonus.text = ("+3");
            Skill1.text = ("+3");
            Skill2.text = ("+3");
            Skill3.text = ("+3");
            Skill4.text = ("+3");
            Skill5.text = ("+3");
            Save.text = ("+3");
        } if (intValue == 18) 
        {
            Bonus.text = ("+4");
            Skill1.text = ("+4");
            Skill2.text = ("+4");
            Skill3.text = ("+4");
            Skill4.text = ("+4");
            Skill5.text = ("+4");
            Save.text = ("+4");
        } if (intValue == 19) 
        {
            Bonus.text = ("+4");
            Skill1.text = ("+4");
            Skill2.text = ("+4");
            Skill3.text = ("+4");
            Skill4.text = ("+4");
            Skill5.text = ("+4");
            Save.text = ("+4");
        } if (intValue == 20) 
        {
            Bonus.text = ("+5");
            Skill1.text = ("+5");
            Skill2.text = ("+5");
            Skill3.text = ("+5");
            Skill4.text = ("+5");
            Skill5.text = ("+5");
            Save.text = ("+5");
        }
    }

}
