using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New skill", menuName = "New skill/skill")]
public class skill : ScriptableObject
{
    public string skillname;
    public Sprite skillimage;
    public GameObject skillprefab;
    public int SkillLevel = 1;
    public int UpgradeMoney = 500;
    [TextArea]          // 엔터치고 쓸수있음 다음줄 이동가능
    public string skillinfo;
}