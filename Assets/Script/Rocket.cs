//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Rocket : MonoBehaviour
//{
//    public float rocketSpeed = 10f;
//    private Transform target;

//     public void SetTarget(Transform target)
//    {
//        this.target = target;
//    }
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    private void Update()
//    {
//        if(target == null)
//        {
//            //
//        }
//        Vector3 direction = (target.position - transform.position).normalized;
//        transform.Translate(direction * rocketSpeed * Time.deltaTime);
//        float distance = Vector3.Distance(transform.position, target.position);
//        if (distance < 0.5f)
//        {
//            HitTarget();
//        }
//    }

//    private void HitTarget()
//    {
//        throw new NotImplementedException();
//    }
//}
