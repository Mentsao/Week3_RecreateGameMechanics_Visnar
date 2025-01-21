using UnityEngine;

public class CharacterCustomization : MonoBehaviour
{
    public GameObject maleModel;
    public GameObject femaleModel;

    private GameObject activeModel; 
    public GameObject[] maleHeads;
    public GameObject[] maleTorsos;
    public GameObject[] maleLegs;

    public GameObject[] femaleHeads;
    public GameObject[] femaleTorsos;
    public GameObject[] femaleLegs;

    private int headIndex = 0;
    private int torsoIndex = 0;
    private int legsIndex = 0;

    void Start()
    {
        SwitchGender(true);
    }

    public void SwitchGender(bool isMale)
{
    if (isMale)
    {
        femaleModel.SetActive(false);  
        maleModel.SetActive(true);
        activeModel = maleModel;
    }
    else
    {
        maleModel.SetActive(false);  
        femaleModel.SetActive(true);
        activeModel = femaleModel;
    }

    headIndex = 0;
    torsoIndex = 0;
    legsIndex = 0;

    UpdateBodyParts();
}


    
    public void NextHead()
    {
        headIndex = (headIndex + 1) % GetActiveHeads().Length;
        UpdateBodyParts();
    }

    
    public void PreviousHead()
    {
        headIndex = (headIndex - 1 + GetActiveHeads().Length) % GetActiveHeads().Length;
        UpdateBodyParts();
    }

    
    public void NextTorso()
    {
        torsoIndex = (torsoIndex + 1) % GetActiveTorsos().Length;
        UpdateBodyParts();
    }

    
    public void PreviousTorso()
    {
        torsoIndex = (torsoIndex - 1 + GetActiveTorsos().Length) % GetActiveTorsos().Length;
        UpdateBodyParts();
    }

    
    public void NextLegs()
    {
        legsIndex = (legsIndex + 1) % GetActiveLegs().Length;
        UpdateBodyParts();
    }

    
    public void PreviousLegs()
    {
        legsIndex = (legsIndex - 1 + GetActiveLegs().Length) % GetActiveLegs().Length;
        UpdateBodyParts();
    }

    private void UpdateBodyParts()
    {
        ToggleParts(GetActiveHeads(), headIndex);
        ToggleParts(GetActiveTorsos(), torsoIndex);
        ToggleParts(GetActiveLegs(), legsIndex);
    }

    private void ToggleParts(GameObject[] parts, int activeIndex)
{
    foreach (GameObject part in parts)
    {
        part.SetActive(false);
    }
    parts[activeIndex].SetActive(true);
}


    private GameObject[] GetActiveHeads()
    {
        return activeModel == maleModel ? maleHeads : femaleHeads;
    }

    private GameObject[] GetActiveTorsos()
    {
        return activeModel == maleModel ? maleTorsos : femaleTorsos;
    }

    private GameObject[] GetActiveLegs()
    {
        return activeModel == maleModel ? maleLegs : femaleLegs;
    }
}
