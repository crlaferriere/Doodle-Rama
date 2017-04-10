using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PaintSpawn : MonoBehaviour
{
    #region Variables
    //Red Bar Supply 
    public float futurecury;
	//Blue Bar Supply
	public float oldcury;
	//Yellow Bar Supply
	public float newcury;
	public float startRedAmount;
    public float startBlueAmount;
	public float startYellowAmount;
	public Slider redSlider;
	public Slider blueSlider;
	public Slider yellowSlider;
	public Image fullRedImage;
	public Image fullBlueImage;
	public Image fullYellowImage;
	public int score; 
	private float currentRedAmount;
	private float currentBlueAmount;
	private float currentYellowAmount;
    private Vector3 mousePosition;
    public float moveSpeed = 1f;
    public bool follow = true;
    public GameObject RedpaintPrefab, BluepaintPrefab, YellowpaintPrefab, paintSpawn;
    public int paintTracker = 0;
    public bool redPaint, bluePaint, yellowPaint, canPaint;
    public int redPaintSupply, bluePaintSupply, yellowPaintSupply;
	public Camera paintCamera; 
	public GameObject redIcon, yellowIcon, blueIcon; 
	public float redSliderAmount, blueSliderAmount, yellowSliderAmount;
	public Texture2D cursorTexture;
	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = Vector2.zero;
    #endregion
    void Awake(){
        //on Awake, initialize the paint amounts
        redSlider.value = startRedAmount;
		blueSlider.value = startBlueAmount;
		yellowSlider.value = startYellowAmount;
	}

    void Start()
	{
        //since the game levels dictate the paint supply initialize those as well
        currentRedAmount = redPaintSupply;
		currentBlueAmount = bluePaintSupply;
		currentYellowAmount = yellowPaintSupply;
	}

	void Update()
    { 	
		PaintRemaining ();		
		ChangePaint (); 
  
        if (follow == true) //the brush follows the mouse cursor
        {
          	mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }


        // paints by instantiating blocks per frame and subtracting the paint amount per block

		if (canPaint == true) {

			if (Input.GetMouseButton (0) && redPaint == true && redPaintSupply > 0) {

				GameObject paint = Instantiate (RedpaintPrefab);
				paint.transform.position = paintSpawn.transform.position;
                redPaintSupply--; 
				PaintAmountUI ();

            }
            else if (Input.GetMouseButton (0) && bluePaint == true && bluePaintSupply > 0)
            {
				GameObject paint = Instantiate (BluepaintPrefab); 
				paint.transform.position = paintSpawn.transform.position;
                bluePaintSupply--; 
				PaintAmountUI ();

            }
            else if (Input.GetMouseButton (0) && yellowPaint == true && yellowPaintSupply > 0)
            {
				GameObject paint = Instantiate (YellowpaintPrefab);
				paint.transform.position = paintSpawn.transform.position;
                yellowPaintSupply--; 
				PaintAmountUI ();
        
			}
			
		}

    }

	public void ChangePaint() {

        //press space to swap between what color you use
		if (Input.GetKeyDown(KeyCode.Space) == true && canPaint == true) { //Tracks which paint is being used 

			paintTracker++;

			if (paintTracker >= 3)
			{
				paintTracker = 0;
			}
        }

        if (paintTracker == 0)
		{
			redPaint = true;
			bluePaint = false;
			yellowPaint = false; 
			redIcon.transform.localScale = new Vector3 (0.4f, .4f, 1f); 
			blueIcon.transform.localScale = new Vector3 (0.2f, .2f, 1f); 
			yellowIcon.transform.localScale = new Vector3 (0.2f, 0.2f, 1f); 

		}
        else if (paintTracker == 1)
		{
			bluePaint = true;
			redPaint = false;
			yellowPaint = false; 
			blueIcon.transform.localScale = new Vector3 (0.4f, .4f, 1f); 
			redIcon.transform.localScale = new Vector3 (0.2f, .2f, 1f); 
			yellowIcon.transform.localScale = new Vector3 (0.2f, .2f, 1f); 

		}
        else if(paintTracker == 2)
		{
			bluePaint = false;
			redPaint = false;
			yellowPaint = true;
			yellowIcon.transform.localScale = new Vector3 (0.4f, .4f, 1f); 
			redIcon.transform.localScale = new Vector3 (0.2f, .2f, 1f); 
			blueIcon.transform.localScale = new Vector3 (0.2f, .2f, 1f); 
		}
	}

	public void PaintRemaining()
	{
        //function to calculate how much paint you have 
		currentRedAmount  = redPaintSupply;
		currentBlueAmount = bluePaintSupply;
		currentYellowAmount = yellowPaintSupply;
		futurecury = currentRedAmount / startRedAmount * -redSliderAmount + startRedAmount;
		oldcury = currentBlueAmount / startBlueAmount * -blueSliderAmount + startBlueAmount;
		newcury = currentYellowAmount / startYellowAmount * -yellowSliderAmount + startYellowAmount;
		PaintAmountUI ();
	}

	public void PaintAmountUI(){
        //displays the proper paint amounts
        redSlider.value = futurecury;
		blueSlider.value = oldcury;
		yellowSlider.value = newcury; // / startYellowAmount;
	}

	void OnMouseEnter() {
		Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
	}
	void OnMouseExit() {
		Cursor.SetCursor(null, Vector2.zero, cursorMode);
	}

}