using UnityEngine;
using TMPro;

public class SingleUnitInfo : MonoBehaviour
{
	[SerializeField]
	TextMeshProUGUI UnitName;
	[SerializeField]
	TextMeshProUGUI UnitHp;
    public void SetUI(string name,int maxHp,int nowHp)
	{
		UnitName.text = name;
		UnitHp.text = nowHp.ToString() + " / " + maxHp.ToString();
	}
	public void UpdateUI(int maxHp, int nowHp)
	{
		UnitHp.text = nowHp.ToString() + " / " + maxHp.ToString();
	}
}
