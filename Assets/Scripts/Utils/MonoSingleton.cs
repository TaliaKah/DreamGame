// Source : https://github.com/UnityCommunity/UnitySingleton/blob/main/Assets/Scripts/MonoSingleton.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : Component
{

    #region Fields

    /// <summary>
    /// The instance.
    /// </summary>
    private static T instance;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the instance.
    /// </summary>
    /// <value>The instance.</value>
    public static T Instance => instance;

    #endregion

    #region Methods

    /// <summary>
    /// Use this for initialization.
    /// </summary>
    protected virtual void Awake()
    {
        if (instance is null)
        {
            instance = this as T;
        }
    }

    #endregion

}