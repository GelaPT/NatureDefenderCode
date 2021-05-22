using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : Singleton<PlayerInventory> {
    private int wood;
    public int Wood {
        get {
            return wood;
        } set {
            wood = value;
            OnWoodChanged();
        }
    }
    [SerializeField] private Text woodText;

    private int metal;
    public int Metal {
        get {
            return metal;
        } set {
            metal = value;
            OnMetalChanged();
        }
    }
    [SerializeField] private Text metalText;

    private void OnWoodChanged() {
        woodText.text = Wood + "x";
    }

    private void OnMetalChanged() {
        metalText.text = Metal + "x";
    }
}
