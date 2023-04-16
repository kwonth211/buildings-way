﻿
using UltimateClean;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class CleanButton : Button
{
    private ButtonSounds buttonSounds;
    private bool pointerWasUp;

    protected override void Awake()
    {
        base.Awake();
        buttonSounds = GetComponent<ButtonSounds>();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (buttonSounds != null && interactable)
        {
            buttonSounds.PlayPressedSound();
        }
        base.OnPointerClick(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        pointerWasUp = true;
        base.OnPointerUp(eventData);
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (pointerWasUp)
        {
            pointerWasUp = false;
            base.OnPointerEnter(eventData);
        }
        else
        {
            if (buttonSounds != null && interactable)
            {
                buttonSounds.PlayRolloverSound();
            }
            base.OnPointerEnter(eventData);
        }
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        pointerWasUp = false;
        base.OnPointerExit(eventData);
    }
}