using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillView : MonoBehaviour
{
    public List<SkillItem> m_skillItemList;

	public void Init(SkillModel _model)
    {
        InitSkillItem(_model);
    }

    void InitSkillItem(SkillModel _model)
    {
        m_skillItemList = new List<SkillItem>();

        GameObject prefab = Resources.Load("PlayScene/Prefabs/SkillItem") as GameObject;
        
        for(int i = 0; i < _model.m_skillItemDataList.Count;i++)
        {
            SkillItem item = ((GameObject)Instantiate(prefab)).GetComponent<SkillItem>();
            item.Init(_model.m_skillItemDataList[i]);
            item.transform.SetParent(this.transform);

            Tile tile = MapManager.GetInst.GetTile(_model.m_skillItemDataList[i].m_tileData);
            
            item.transform.position = tile.transform.position; 

            m_skillItemList.Add(item);
        }            
    }

    public void UpdateView()
    {

    }

    public void DisableSkillItem(SkillItemData _data)
    {
        SkillItem si = m_skillItemList[_data.m_id];
        si.Disable();
    }
}
