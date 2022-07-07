using System;
using UnityEngine;

namespace BTree.Runtime
{
  [Serializable]
  public abstract class Node
  {
    public enum State
    {
      Running,
      Failure,
      Success
    }
    
    
    public string guid;
    public string description;
    
    public string name { get; private set; }
    public State state { get; private set; }
    
    protected Node()
    {
      guid = Guid.NewGuid().ToString();
      name = GetType().FullName;
    }

    public virtual void AddChild(Node node) => OnAddChild(node);

    public virtual void RemoveChild(Node node) => OnRemoveChild(node);

    protected virtual void OnAddChild(Node child)
    {
    }

    protected virtual void OnRemoveChild(Node child)
    {
    }

    public State Evaluate<T>(T context) where T : IContext => state = OnEvaluate(context);

    protected abstract State OnEvaluate<T>(T context) where T : IContext;

    public virtual void Traverse(Action<Node> visitor) => visitor.Invoke(this);

    public static void Traverse(Node node, Action<Node> visitor) => node?.Traverse(visitor);
  }
}