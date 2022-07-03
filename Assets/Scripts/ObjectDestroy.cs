using UnityEngine;
using UnityEngine.Events;

public class ObjectDestroy: MonoBehaviour
{
    [Serializable]
    /// <summary>
    /// Function definition for a key pressed event
    /// </sumarry>
    public class keyEvent: UnityEvent{
        public KeyCode key = KeyCode.Return;
 
        public keyEvent(){}
 
        public keyEvent(KeyCode _keycode) {
            key = _keycode;
        }
    }
 
    [SerializeField]
    private keyEvent keyA = new keyEvent(KeyCode.A);
 
    [SerializeField]
    private keyEvent keyW = new keyEvent(KeyCode.W);
 
    [SerializeField]
    private keyEvent keyS = new keyEvent(KeyCode.S);

    [SerializeField]
    private keyEvent keyD = new keyEvent(KeyCode.D);

    [SerializeField]
    private keyEvent keyQ = new keyEvent(KeyCode.Q);

    [SerializeField]
    private keyEvent keyZ = new keyEvent(KeyCode.Z);
 
    void Update(){
        if(Input.GetKeyUp(keyA.key)){
            keyA.Invoke();
        }
        if(Input.GetKeyUp(keyW.key)){
            keyW.Invoke();
        }
        if(Input.GetKeyUp(keyS.key)){
            keyS.Invoke();
        }
        if(Input.GetKeyUp(keyD.key)){
            keyD.Invoke();
        }
        if(Input.GetKeyUp(keyQ.key)){
            keyQ.Invoke();
        }
        if(Input.GetKeyUp(keyZ.key)){
            keyZ.Invoke();
        }
    }
}
