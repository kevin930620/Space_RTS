using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ConstructionShip : ShipBase
{

	Coroutine curretCoroutine;

	float miningCD;
	float totalMiningCD;
	[SerializeField]
	Transform TargetUnit;
	[SerializeField]
	Vector3 targetPosition;
	Vector2 basePosition;


	GameObject isHeld = null;

	public ConstructionShip(ShipBase shipInfo) : base(shipInfo)
	{
	}

	//public ConstructionShip(float totalMiningCD, Vector3 targetPosition, float spd, float atkRange, float totalAtkCd, int max_Hp, int def, float scanRange, string unitName) :
	//	base(spd, atkRange, totalAtkCd, max_Hp,def,scanRange, unitName) {
	//	this.totalMiningCD = totalMiningCD;

	//}
	protected override void Awake()
	{
		base.Awake();
	}
	private void Start()
	{

	}
	protected override void Update()
	{
		base.Update();
	}
}
