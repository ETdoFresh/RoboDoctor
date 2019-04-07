using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngineEvent = UnityEngine.Events.UnityEvent;
using Object = UnityEngine.Object;

[Serializable] public class UnityEvent : UnityEngineEvent { }
[Serializable] public class UnityEventObject : UnityEvent<Object> { }
[Serializable] public class UnityEventGameObject : UnityEvent<GameObject> { }
[Serializable] public class UnityEventTransform : UnityEvent<Transform> { }
[Serializable] public class UnityEventBaseEventData : UnityEvent<BaseEventData> { }
[Serializable] public class UnityEventPointerEventDate : UnityEvent<PointerEventData> { }