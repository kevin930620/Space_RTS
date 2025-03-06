using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Bullet : MonoBehaviour
{

	int atkValue = 0;

	[SerializeField]
	private GameObject target;


	public void Init(int atkValue, GameObject target)
	{
		this.atkValue = atkValue;
		this.target = target;
	}
	private void Start()
	{
		if(target == null)Destroy(gameObject);
	}

	private void Update()
	{
		if (target == null || target.Equals(null))
		{
			Destroy(gameObject, 3);
		}
		else
		{
			Vector3 dir = (target.transform.position - transform.position).normalized;
			dir.z = 0;

			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

			// 設定旋轉角度
			transform.rotation = Quaternion.Euler(0, 0, angle - 90);

			transform.Translate(dir * 5 * Time.deltaTime);
		}
		
	}
	// Update is called once per frame


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (target.gameObject == collision.gameObject){
			if (!collision.isTrigger && collision is BoxCollider2D)
			{
				collision.GetComponent<ShipBase>().GetHit(atkValue);
				Destroy(gameObject);
			}
			

		}
	}
}
