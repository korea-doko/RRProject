using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCommandContainerPanel : MonoBehaviour {

    public List<SkillCommandPanel> m_skillPanelList;
    public static SkillCommandContainerPanel m_inst;
    public static SkillCommandContainerPanel GetInst
    {
        get { return m_inst; }
    }
    public SkillCommandContainerPanel()
    {
        m_inst = this;
    }
    //public void Init(List<Skill> _skList)
    //{
    //    m_skillPanelList = new List<SkillCommandPanel>();

    //    GameObject prefab = Resources.Load("SkillCommandPanel") as GameObject;

    //    for(int i = 0; i < _skList.Count;i++)
    //    {
    //        SkillCommandPanel p = ((GameObject)Instantiate(prefab)).GetComponent<SkillCommandPanel>();
    //        p.transform.SetParent(this.transform);
    //        p.Init(_skList[i]);
    //    }        
    //}
}
