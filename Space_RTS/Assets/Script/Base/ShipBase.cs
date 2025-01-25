using UnityEngine;

public abstract class ShipBase : Unit
{

	float SPD;
	float atkRange;
	float totalAtkCD;
	float atkCd = 0f;

	Faction belongFaction;
	ShipBase[] nearByList;
	ShipBase target;

	protected ShipBase(float spd, float AtkRange, float totalAtkCd,int max_Hp, int def, float scanRange, string name) : base(max_Hp,def,scanRange,name) {
		this.SPD = spd;
		this.atkRange = AtkRange;
		this.totalAtkCD = totalAtkCd;
	}

	// 方法
	protected virtual void Move(Vector3 position)
	{
		Debug.Log(position);
	} // 移動至目標位置
	protected virtual void Attack(Unit target) { 
		
	}
	
	protected virtual void AutoScan() { 
	
	} // 自動掃描
	protected virtual void AutoMove() { 
	
	} // 自動移動
	protected virtual void TakeDamage(Attack attack) { 
	
	} // 受到傷害
	protected virtual void AutoAttack() { 
	
	} // 自動攻擊
}
