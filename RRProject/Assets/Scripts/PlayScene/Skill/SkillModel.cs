using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillModel : MonoBehaviour
{
    public int m_numOfSkillItem;

    public List<SkillData> m_skillDataList;             // 모든 스킬들
    public List<Sprite> m_skillSpriteList;              // 스킬 이미지
    public List<SkillItemData> m_skillItemDataList;     // 스킬 + 어디에 있냐? 생성된 스킬 아이템


	public void Init()
    {
        m_numOfSkillItem = 20;

        InitSpriteList();
        InitSkillData();
        InitSkillItemDataList();
    }

    void InitSpriteList()
    {
        m_skillSpriteList = new List<Sprite>();

        Sprite[] sps = Resources.LoadAll<Sprite>("PlayScene/Images/Skills");

        for (int i = 0; i < sps.Length; i++)
            m_skillSpriteList.Add(sps[i]);

    }
    void InitSkillData()
    {
        m_skillDataList = new List<SkillData>();

        for (int i = 0; i < 8; i++)
        {
            int numOfCombo = Random.Range(3, 5);
            KeyCode[] code = new KeyCode[numOfCombo];

            for (int k = 0; k < numOfCombo; k++)
            {
                int q = Random.Range(0, 7);
                KeyCode key = KeyCode.A;

                if (q == 0)
                    key = KeyCode.A;
                else if (q == 1)
                    key = KeyCode.S;
                else if (q == 2)
                    key = KeyCode.D;
                else if (q == 3)
                    key = KeyCode.W;
                else if (q == 4)
                    key = KeyCode.J;
                else if (q == 5)
                    key = KeyCode.K;
                else if (q == 6)
                    key = KeyCode.L;
                else
                    key = KeyCode.I;


                code[k] = key;
            }

            SkillData skill = new SkillData("Skill Name" + i.ToString(), code);
            m_skillDataList.Add(skill);
        }

    }
    void InitSkillItemDataList()
    {
        m_skillItemDataList = new List<SkillItemData>();

        for(int i = 0; i < m_numOfSkillItem;i++)
        {
            SkillData skillData = GetRandomSkillData();
            TileData tileData = MapManager.GetInst.GetValidRandomTileData();

            SkillItemData sid = new SkillItemData(i,skillData,tileData);
            m_skillItemDataList.Add(sid);
        }
    }

    SkillData GetRandomSkillData()
    {
        int rand = UnityEngine.Random.Range(0, m_skillDataList.Count);
        return m_skillDataList[rand];
    }
}
