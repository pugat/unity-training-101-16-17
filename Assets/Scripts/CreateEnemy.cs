using UnityEngine;
using System.Collections;

public class CreateEnemy : MonoBehaviour {

    public Transform _enemys;
    public GameObject _enemy;

    public Transform _assasins;
    public GameObject _assain;

    public int _enemySize;
    public int _assasinSize;


    void Start () {
        for (int i = 0; i < _enemySize; i++)
        {
            Create(_enemy,_enemys);
        }

        for (int i = 0; i < _assasinSize; i++)
        {
            Create(_assain,_assasins);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            if (_enemys.childCount < _enemySize)
            {
                Debug.Log("T");
                Create(_enemy,_enemys);
            }
            
        }
    }

    void OnMouseDown()
    {
        Debug.Log("fare");
        //Create();
    }

    void Create(GameObject _prefab,Transform _parent)
    {
        GameObject _temp = Instantiate(_prefab, new Vector3(Random.Range(5f, 44f), 2f, Random.Range(5f, 44f)), Quaternion.identity) as GameObject;
        _temp.transform.parent = _parent;
    }
}
