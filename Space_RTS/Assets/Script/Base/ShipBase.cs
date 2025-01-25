using UnityEngine;

public abstract class ShipBase : Unit
{

	float SPD;
	float TotalAtkCD;
	float AtkCd = 0f;

	Faction BelongFaction;
	ShipBase[] NearByList;
	ShipBase Target;

	protected ShipBase(int max_Hp, int def, float scanRange, string name, float spd,float totalAtkCd) : base(max_Hp,def,scanRange,name) {
		this.SPD = spd;
		this.TotalAtkCD = totalAtkCd;
	}

	// 方法
	protected virtual void Move(Vector3 position)
	{
		Debug.Log(position);
	} // 移動至目標位置
	protected virtual void Attack(ShipBase target) { 
		
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
