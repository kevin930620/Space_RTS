using UnityEngine;

public class ConstructionShip : ShipBase
{
	float MiningCD;
	float TotalMiningCD;
	Vector2 TargetPosition;
	public ConstructionShip(float totalMiningCD, Vector3 targetPosition, int max_Hp, int def, float scanRange, string name, float spd, float totalAtkCd) : base(max_Hp,def,scanRange,name,spd,totalAtkCd) {
		this.TotalMiningCD = totalMiningCD;
		if (targetPosition != null) { Move(targetPosition); }
	}
	protected override void Move(Vector3 position)
	{
		base.Move(position);
	}
	void Mining() { 
		
	}
}
