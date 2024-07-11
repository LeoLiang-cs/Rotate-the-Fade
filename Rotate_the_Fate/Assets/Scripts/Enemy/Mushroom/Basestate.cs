using UnityEngine;

public abstract class Basestate : MonoBehaviour
{
    protected Enemy currenemy;
    public abstract void OnEnter(Enemy enmy);

    public abstract void Logicupdate();


    public abstract void pythicupdate();





    public abstract void OnExit();
}

