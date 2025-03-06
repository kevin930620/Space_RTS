using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class InfoBase
{
	public int MAXHP;
	public int DEF;
	public float ScanRange;
	public string UnitName;
}

public abstract class Unit : MonoBehaviour
{
	// 屬性
	protected int MAX_HP;
	protected int HP;
	protected int DEF;
	protected float scanRange;
	protected string unitName;
	private ShipBase infoBase;

	protected Unit(InfoBase infoBase) { 
		MAX_HP = infoBase.MAXHP;
		HP = MAX_HP;
		DEF = infoBase.DEF;
		scanRange = infoBase.ScanRange;
		unitName = infoBase.UnitName;
		
	}

	protected Unit(ShipBase infoBase)
	{
		this.infoBase = infoBase;
	}

	protected virtual void Init(InfoBase infoBase)
	{
		MAX_HP = infoBase.MAXHP;
		HP = MAX_HP;
		DEF = infoBase.DEF;
		scanRange = infoBase.ScanRange;
		unitName = infoBase.UnitName;
		GetComponent<CircleCollider2D>().radius = scanRange;
	}
	protected int GetHp() { return HP; }
	protected int GetDef() { return DEF; }
	protected string GetName() { return unitName; }

	protected virtual void TakeDamage( int damage) {
		HP -= damage;
		if (HP <= 0) Destroy(gameObject);
	}
	protected virtual void ChangeName(string newName) {
		unitName = newName;
	}

}
