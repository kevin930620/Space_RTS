using UnityEngine;

public abstract class Unit : MonoBehaviour
{
	// 屬性
	protected int MAX_HP;
	protected int HP;
	protected int DEF;
	protected float scanRange;
	protected string unitName;

	protected Unit(int max_Hp,int def,float scanRange,string unitName) { 
		this.MAX_HP = max_Hp;
		this.HP = this.MAX_HP;
		this.DEF = def;
		this.scanRange = scanRange;
		this.unitName = unitName;
	}
	protected int GetHp() { return HP; }
	protected int GetDef() { return DEF; }
	protected string GetName() { return unitName; }

	protected virtual void TakeDamage( int damage) {
		HP -= damage;
	}
	protected virtual void ChangeName(string newName) {
		unitName = newName;
	}

}
