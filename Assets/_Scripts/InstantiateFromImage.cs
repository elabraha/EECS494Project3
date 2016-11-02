using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InstantiateFromImage : MonoBehaviour
, IPointerClickHandler 
{
	public GameObject prefab;
	SpriteRenderer sprite;
	Color target = Color.white;
	GameObject newobj;
	Color black = Color.black;
	Image imagesprite;
	public int limit;
	int amounton = 0;
	public Text text;
	public bool disabled;

	void Awake() {

		sprite = GetComponent<SpriteRenderer>();
		imagesprite = GetComponentsInChildren <Image>()[1];
	}

	void Start() {
		if (disabled)
			imagesprite.color = black;
			
	}
	

	void Update()
	{
		if(!disabled)
			text.text = (limit - amounton).ToString();
		if (sprite)
			sprite.color = Vector4.MoveTowards(sprite.color, target, Time.deltaTime * 10);
	}

	// Use this for initialization
	public void OnPointerClick(PointerEventData eventData) // 3
	{
		if (WinGameEvent.G.deadyet >= 0 && !disabled && amounton < limit) {
			print ("I was clicked");
			print (disabled);
			target = Color.green;
			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector3 pos = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width / 2, Screen.height / 2, 30.0f));
			pos.z = 30.0f;

			newobj = Instantiate (prefab, pos, Quaternion.identity) as GameObject;
			amounton += 1;
		}
	}

//	public void OnPointerEnter(PointerEventData eventData)
//	{
//		print ("create");
//		target = Color.green;
//		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//		if (Physics.Raycast (ray)) {
//			newobj  = Instantiate (prefab, transform.position, transform.rotation) as GameObject;
//			//newobj.gameObject
//		}
//	}

//	public void OnPointerExit(PointerEventData eventData)
//	{
//		newobj.transform.position = Camera.main.ViewportToScreenPoint (0.0f, 0.0f, 0.0f);
//	}
}
