using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
   [SerializeField] private Subject subjectToObserve;
   
   private void OnThingHappened()
   {
      // 이벤트에 응답하는 모든 로직은 여기로 이동
      Debug.Log("Observer responds");
   }

   private void Awake()
   {
      if (subjectToObserve != null)
      {
         subjectToObserve.ThingHappened += OnThingHappened;
      }
   }

   private void OnDestroy()
   {
      if (subjectToObserve != null)
      {
         subjectToObserve.ThingHappened -= OnThingHappened;
      }
   }
}
