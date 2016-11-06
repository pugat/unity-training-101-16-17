using UnityEngine;
using System.Collections;

public class Assasin : MonoBehaviour {

    int _originX;
    bool _right = false;

	// Use this for initialization
	void Start () {
        _originX = (int)transform.position.x;
        //Debug.Log(_originX);
    }
	
	// Update is called once per frame
	void Update () {
  
        if (_right == false)
        {
            transform.Translate(Vector3.Lerp(transform.position, new Vector3(0.1f, 0f, 0f), 10f));
            
            if (transform.position.x > _originX + 5f)
            {
                _right = true;
            }
        }
        else if (_right == true)
        {
            transform.Translate(Vector3.Lerp(transform.position, new Vector3(-0.1f, 0f, 0f), 10f));
            if (transform.position.x < _originX - 5f)
            {
                _right = false;
            }
        }
    }
    void OnTriggerEnter(Collider _col)
    {
        if (_col.tag == "Player")
        {
            //destroy
            Debug.Log("Oldu");
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
