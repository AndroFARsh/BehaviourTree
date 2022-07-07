using System;
using System.Collections.Generic;

namespace BTree.Runtime.Composites
{
  [Serializable]
  public class RandomSelector : CompositeNode
  {
    private readonly ISet<int> indexSet = new HashSet<int>();

    protected override State OnEvaluate<T>(T context)
    {
      indexSet.Clear();
      while (indexSet.Count < Children.Count)
      {
        var child = RequestRandomChild();
        switch (child.Evaluate(context))
        {
          case State.Running:
            return State.Running;
          case State.Success:
            return State.Success;
          case State.Failure:
            continue;
          default:
            throw new ArgumentOutOfRangeException();
        }
      }

      return State.Failure;
    }

    private Node RequestRandomChild()
    {
      int index;
      do
      {
        index = UnityEngine.Random.Range(0, Children.Count);
      } while (indexSet.Contains(index));

      indexSet.Add(index);
      return Children[index];
    }
  }
}