using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour {

    public Card card;
    public Text cardName;
    public Text attack;
    public Text hp;
    public Text manaCost;
    public Text description;
    public Image image;
	void Start ()
    {
        cardName.text = card.name;
        attack.text = card.attack.ToString();
        hp.text = card.health.ToString();
        manaCost.text = card.manaCost.ToString();
        description.text = card.description;
        image.sprite = card.artwork; 

    }
	
	
}
