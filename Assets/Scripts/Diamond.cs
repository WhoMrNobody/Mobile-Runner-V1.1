using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Diamond : MonoBehaviour
{

    void Start() {
        transform.DOMove(new Vector3(transform.position.x, 1.6f, transform.position.z), 2f).SetEase(Ease.InOutCirc).SetLoops(-1, LoopType.Yoyo);
    }

    void OnTriggerEnter(Collider coll) {
        if(coll.CompareTag("Player")){
            transform.DOScale(new Vector3(0f, 0f, 0f), 1f).SetEase(Ease.InCubic);
        }
    }
}
