using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseComponent : MonoBehaviour
{
    public static Application application = new Application();

    protected void bind()
    {
        application.singlethon(this.GetType().Name, this);
    }
}
