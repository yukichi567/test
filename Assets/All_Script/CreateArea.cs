using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateArea : MonoBehaviour
{
    [SerializeField] GameObject[] _item;
    [SerializeField] float _interval;
    BoxCollider2D _bc;
    Transform _tf;
    float _time;

    //[SerializeField] float _tagetarea = 30f;
    //float m_h;
    //GameObject PlayerObject;
    //Vector2 PlayeyPosition;
    //Vector2 SponerPosotion;
    //bool _Object = false;
    // Start is called before the first frame update
    void Start()
    {
        _bc = GetComponent<BoxCollider2D>();
        _tf = GetComponent<Transform>();

        //PlayerObject = GameObject.FindWithTag("Player");
        //PlayeyPosition = PlayerObject.transform.position;
        //SponerPosotion = transform.position;
    }

    // Update is called once per frameq 
    void Update()
    {
        _time += Time.deltaTime;

        float RandomX = Random.Range((-_bc.size.x) / 2, (_bc.size.x) / 2);
        float RandomY = Random.Range((-_bc.size.y) / 2, (_bc.size.y) / 2);
        int n = Random.Range(0, _item.Length);

        if (_time >= _interval)
        {
            GameObject _Item = Instantiate<GameObject>(_item[n]);
            _Item.transform.position = new Vector2(RandomX + transform.position.x, RandomY + transform.position.y);
            _time = 0;
        }

        //m_h = Input.GetAxisRaw("Horizontal");
        //PlayeyPosition = PlayerObject.transform.position;
        //SponerPosotion = transform.position;
        //float distance = Vector2.Distance(SponerPosotion, PlayeyPosition);

        //if (distance < _tagetarea )
        //{
        //    _Object = true;
        //}
        //else 
        //{
        //    _Object = false;
        //}
    }
}