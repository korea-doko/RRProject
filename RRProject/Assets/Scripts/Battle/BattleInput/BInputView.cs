using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BInputView : MonoBehaviour
{
    public Text m_commandText;
    public Text m_comboText;

    public void Init(BInputModel _model)
    {
        m_commandText = GameObject.Find("CommandText").GetComponent<Text>();
        m_commandText.text = "Command = ";

        m_comboText = GameObject.Find("ComboText").GetComponent<Text>();
        m_comboText.text = "Combo / MaxCombo = ";
    }

    public void GetCombo(BInputModel _model)
    {
        m_comboText.text = "Combo / MaxCombo = " + _model.m_curComboCount.ToString() + " / " + _model.m_maxComboCount.ToString();
    }
    public void ComboFail(BInputModel _model)
    {
        m_comboText.text = "Combo / MaxCombo = 0 /" + _model.m_maxComboCount.ToString();
    }
    public void GetCommand(KeyCode _code)
    {
        m_commandText.text += _code.ToString() + " ";
    }
    public void CommandFail()
    {
        m_commandText.text = "Command = ";             
    }
    
    public void Clear()
    {
        m_commandText.text = "Command = ";
        m_comboText.text = "Combo / MaxCombo = ";
    }
}
