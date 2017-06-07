using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BInputModel : MonoBehaviour {

    public int m_maxComboCount;
    public int m_curComboCount;

	public void Init()
    {
        m_maxComboCount = 0;
        m_curComboCount = 0;
    }
    
    public void ComboSuccess()
    {
        m_curComboCount++;
    }
    public void ComboFail()
    {
        if (m_curComboCount > m_maxComboCount)
            m_maxComboCount = m_curComboCount;

        m_curComboCount = 0;
    }
}
