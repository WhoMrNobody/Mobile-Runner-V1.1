using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrap : MonoBehaviour
{   
    [HideInInspector] public Mesh objectMesh;
    public bool isTrapActivated =false;
    public MoveableTraps moveableTraps;
    float _trapMoveSpeed;
    float _trapRotationSpeed=1f;
    Vector3 _currentTransformPos;
    void Start() {
        
        _trapMoveSpeed=moveableTraps.trapMoveSpeed;
        objectMesh=moveableTraps.trapMesh;
        _currentTransformPos = transform.position;

    }
    void Update()
    {
        
        if(isTrapActivated){

            transform.Translate(Vector3.back * _trapMoveSpeed * Time.deltaTime, Space.World);
            transform.Rotate(-_trapRotationSpeed, transform.rotation.y, transform.rotation.z);
            Destroy(gameObject, 10f);
            
        }

        if(GameManager.Instance.gameStatusValue== GameManager.GameStatus.NONE){
            transform.position= _currentTransformPos;
            isTrapActivated=false;
        } 
    }

    void OnTriggerEnter(Collider other) {
        
        if(other.CompareTag("Obstacle")) Destroy(gameObject);
    }
}
