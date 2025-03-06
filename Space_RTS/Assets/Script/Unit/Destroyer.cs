using System;
using UnityEngine;

public class Destroyer : ShipBase
{
	[SerializeField]
	ShipInfo shipInfo;

	public Destroyer(ShipBase shipInfo) : base(shipInfo)
	{
	}

	//public Destroyer(float spd, float atkRange, float totalAtkCd, int max_Hp, int def, float scanRange, string unitName) : base(spd, atkRange, totalAtkCd, max_Hp, def, scanRange, unitName)
	//{
	//}
	protected override void Awake()
	{
		InitShip(shipInfo);
		base.Awake();
	}
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

	// Update is called once per frame
	protected override void Update()
	{
		base.Update();
	}
}
