using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class Hammer : XRGrabInteractable
{
    public Anvil anvil; // ссылка на компонент наковальни

    private UnityEvent<SelectExitEventArgs> selectExitedEvent;

    protected override void Awake()
    {
        base.Awake();
        selectExitedEvent = new UnityEvent<SelectExitEventArgs>();
    }

    [System.Obsolete]
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);
        selectExitedEvent.AddListener(DropHammer);
    }

    [System.Obsolete]
    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);
        selectExitedEvent.RemoveListener(DropHammer);
    }

    private void DropHammer(SelectExitEventArgs args)
    {
        anvil.HitWithHammer();
    }
}

