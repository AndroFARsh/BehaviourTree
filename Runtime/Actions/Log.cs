using System;
using UnityEngine;

namespace BTree.Runtime.Actions
{
  [Serializable]
  public class Log : ActionNode
  {
    public string message;
    public State returnState = State.Success;
    
    protected override State OnEvaluate<T>(T context)
    {
      Debug.Log($"{message}");
      return returnState;
    }
  }
}