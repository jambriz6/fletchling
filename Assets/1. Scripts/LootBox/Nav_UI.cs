using UnityEngine;
using UnityEngine.UI;

public class Nav_UI : MonoBehaviour
{
    public Text packCountText; // Reference to the UI Text component that displays the pack count

    // Method to update the pack count in the UI
    public void UpdatePackCount(int count)
    {
        packCountText.text = "Packs Avialable: " + count.ToString();
    }
}
