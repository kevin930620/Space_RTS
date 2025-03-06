using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[System.Serializable]
public class ShipInfo:InfoBase
{

	public float SPD;
	public int AtkValue;
	public float AtkRange;
	public float TotalAtkCD;

}

public abstract class ShipBase : Unit
{
	

	float SPD;
	int atkValue;
	float atkRange;
	float totalAtkCD;
	float atkCd = 0f;

	Color originalColor;
	SpriteRenderer spriteRenderer;

	[SerializeField]
	bool IsAI = false;
	[SerializeField]
	NavMeshAgent agent;
	//Faction belongFaction;
	public  List<GameObject> nearByList = new List<GameObject>();
	
	Unit target;
	
	[SerializeField]
	GameObject HpBar;

	[SerializeField]
	GameObject Bullet;
	

	protected ShipBase(ShipBase shipInfo) : base(shipInfo)
	{
		SPD = shipInfo.SPD;
		totalAtkCD = shipInfo.totalAtkCD;
		atkValue = shipInfo.atkValue;
		atkCd = 0f;
	}
	protected virtual void InitShip(ShipInfo shipInfo)
	{
		SPD = shipInfo.SPD;
		GetComponent<NavMeshAgent>().speed = SPD;
		totalAtkCD = shipInfo.TotalAtkCD;
		atkValue = shipInfo.AtkValue;
		base.Init(shipInfo);
		
	}
	protected virtual void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
		spriteRenderer = GetComponent<SpriteRenderer>();
		originalColor = spriteRenderer.color;

		totalAtkCD = 5f;
		atkCd = 0f;
		atkRange = 5f;


	}
	private void Start()
	{
		HpBar.GetComponent<UnitHpBar>().SetHPBar(HP, MAX_HP);
	}
	protected virtual void Update() {
		if (atkCd != 0) atkCd -= Time.deltaTime;
		if (target == null) AutoAttack();
		else
		{
			
			if (Vector2.Distance(target.transform.position, transform.position) > atkRange) Move(target.transform.position);
			else
			{
				
				Move(transform.position);
				Attack(target);
			}
		}

		if (agent.velocity.sqrMagnitude > 0.1f) // 有移動時才旋轉
		{
			Vector3 direction = agent.velocity.normalized; // 移動方向
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0, 0, angle-90); // 設置旋轉
		}
	}
	private void LateUpdate()
	{
		Vector3 position = agent.transform.position;
		position.z = 0f;  // 強制鎖定 z 軸
		agent.transform.position = position;
	}
	// 方法
	public virtual void Move(Vector3 position)
	{
		agent.isStopped = true;
		agent.SetDestination(position);
		agent.isStopped = false;
	} // 移動至目標位置
	public virtual void SettingTarget(Unit target)
	{
		this.target = target;
	}
	protected virtual void Attack(Unit target) {
		
		//是否有子彈Prefab
		if (Bullet == null) return;
		//Debug.Log(IsFacingTarget(target.transform));
		//目標是否超過攻擊距離
		if (Vector2.Distance(transform.position, target.transform.position) > atkRange)return;
		//攻擊是否在冷卻
		if (atkCd <= 0f)
		{
			
			GameObject bullet = Instantiate(Bullet,transform.position,Quaternion.identity);
			
			Vector2 direction = target.transform.position - transform.position;
			float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			bullet.transform.rotation = Quaternion.Euler(0, 0, angle-90);
			var bul = bullet.GetComponent<Bullet>();
			bul.Init(atkValue, target.gameObject);
			atkCd = totalAtkCD;
		}


	}
	
	//protected virtual void AutoScan()
	//{
	//	Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, scanRange);

	//	if (nearByList != null) nearByList.Clear();

	//	foreach (Collider2D collider in colliders)
	//	{


	//		ShipBase unit = collider.GetComponent<ShipBase>();
	//		if (unit != this)
	//		{
	//			Debug.Log($"{name} +{collider.name}");
	//		}
	//		if (unit != null && unit != this)
	//		{
	//			nearByList.Add(unit);

	//		}

	//	}
	//	Debug.Log($"{name} 掃描完成:");
	//} // 自動掃描
	protected virtual void AutoMove() { 
	
	} // 自動移動
	protected virtual void TakeDamage() { 
	
	} // 受到傷害
	protected virtual void AutoAttack() {
		if (nearByList.Count == 0) return;
		Attack(nearByList[0].GetComponent<Unit>());
		HpBar.GetComponent<UnitHpBar>().SetHPBar(HP, MAX_HP);
		

	} // 自動攻擊
	bool IsFacingTarget(Transform target)
	{
		Vector3 directionToTarget = (target.position - transform.position).normalized; // obj1 指向 obj2 的方向
		Vector3 obj1Forward = transform.right.normalized; // 物件1 的前方方向 (2D 預設 X 軸為前方)

		float dot = Vector3.Dot(directionToTarget, obj1Forward); // 計算兩者的夾角關係

		return dot > 0.99f; // 當 dot 非常接近 1 時，代表方向幾乎一致
	}
	public virtual void GetHit(int bullet) {
		TakeDamage(bullet);
	}

	public void Select()
	{
		spriteRenderer.color = Color.red;
	}

	public void Deselect()
	{
		spriteRenderer.color = originalColor;
	}

	protected virtual void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.isTrigger && collision.GetComponent<ShipBase>() != null)
		{
			nearByList.Add(collision.gameObject);
		}
		SortNearByList();
		//Debug.Log($"{name}周圍有" + nearByList.Count);
	}
	protected virtual void OnTriggerExit2D(Collider2D collision)
	{
		if (!collision.isTrigger && collision.GetComponent<ShipBase>() != null)
		{
			nearByList.Remove(collision.gameObject);
		}
		SortNearByList();
		//Debug.Log($"{name}周圍有" + nearByList.Count);

	}
	protected void ClearAction()
	{
		target = null;
	}
	protected void SortNearByList()
	{
		nearByList = nearByList.OrderBy(obj =>
			(transform.position - obj.transform.position).sqrMagnitude).ToList();
	}
}
