using UnityEngine;

public abstract class Unit : MonoBehaviour
{
	// 屬性
	protected int MAX_HP;
	protected int HP;
	protected int DEF;
	protected float ScanRange;
	protected string Name;

	protected Unit(int max_Hp,int def,float scanRange,string name) { 
		this.MAX_HP = max_Hp;
		this.HP = this.MAX_HP;
		this.DEF = def;
		this.ScanRange = scanRange;
		this.Name = name;
	}
	protected int GetHp() { return HP; }
	protected int GetDef() { return DEF; }
	protected string GetName() { return Name; }


}
