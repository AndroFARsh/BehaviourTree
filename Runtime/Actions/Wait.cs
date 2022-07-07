using System;
using UnityEngine;

namespace BTree.Runtime.Actions
{
  [Serializable]
  public class Wait : ActionNode
  {
    public float duration = 1;

    [NonSerialized] private float startTime = -1;

    protected override State OnEvaluate<T>(T context)
    {
      if (startTime < 0)
      {
        startTime = Time.time;
      }
      else if (Time.time - startTime > duration)
      {
        startTime = -1;
        return State.Success;
      }

      return State.Running;
    }
  }
}