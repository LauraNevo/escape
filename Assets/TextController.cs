using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	public Text inventory_text;
	
	private enum States {
		room, slippers, door, photo, take_photo, corridor, crosswords,
		cupboard, drawers, secret_drawers, lift, give_crosswords, hall, tea_room, phone,
		phonecall, reception, caught, missing_objects ,freedom
		};
	private bool item_slippers = false;
	private bool item_crosswords = false;
	
	private bool item_hobnobs = false;
	private bool item_teaset = false;
	private bool item_cranberry = false;
	
	private bool event_teresa = false;
	private bool event_lift_blocked = true;
	private bool event_nurse = false;
	
	int phone_count = 0;
		
	private States myState;
	
	
	// Use this for initialization
	void Start () {
		myState = States.room;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if 		(myState == States.room)				{state_room();}
		else if (myState == States.slippers)			{state_slippers();}
		else if (myState == States.door)				{state_door();}
		else if (myState == States.photo)				{state_photo();}
		else if (myState == States.take_photo)			{state_take_photo();}
		
		else if (myState == States.corridor)			{state_corridor();}
		else if (myState == States.drawers)				{state_drawers();}
		else if (myState == States.secret_drawers)		{state_secret_drawers();}
		else if (myState == States.lift)				{state_lift();}
		else if (myState == States.cupboard)			{state_cupboard();}
		else if (myState == States.give_crosswords)		{state_give_crosswords();}
		
		else if (myState == States.hall)				{state_hall();}
		else if (myState == States.tea_room)			{state_tea_room();}
		else if (myState == States.phone)				{state_phone();}
		else if (myState == States.phonecall)			{state_phonecall();}
		else if (myState == States.reception)			{state_reception();}
		else if (myState == States.caught)				{state_caught();}
		else if (myState == States.missing_objects)		{state_missing_objects();}
		else if (myState == States.freedom)				{state_freedom();}
		
		write_inventory ();
	}
	
	void write_inventory () {
		inventory_text.text = "MY INVENTORY: ";
		if (item_slippers)		{inventory_text.text = inventory_text.text + "slippers";}
		if (item_crosswords)	{inventory_text.text = inventory_text.text + ", crosswords";}
		if (item_hobnobs)		{inventory_text.text = inventory_text.text + ", hobnobs";}
		if (item_teaset)		{inventory_text.text = inventory_text.text + ", tea set";}
		if (item_cranberry)		{inventory_text.text = inventory_text.text + ", cranberry sauce";}
	}
	
	void state_room () {
		text.text = "Your room is cold, impeccably clean and utterly boring. The walls and bed sheets " +
					"are a vile salmon colour. You hate salmon. In any shape, colour or concept. The " +
					"sunlight has disappeared for a few hours. It's now the perfect time to escape.\n\n" +
					
					"You can see slippers on the side of your bed, the door is closed and there's a " +
					"single photo frame on your bed side table.\n\n";
				
		if (!item_slippers) {
			text.text = text.text + "<b>Press S to inspect the slippers, D to check the door and P to look " +
									"at the photo frame.</b>";
		 	}
		 	
		else {
			text.text = text.text + "<b>Press D to check the door and P to look at the photo frame.</b>";
		}
					
		if (Input.GetKeyDown (KeyCode.S) && (!item_slippers))	{myState = States.slippers;}
		else if (Input.GetKeyDown (KeyCode.D))					{myState = States.door;}
		else if (Input.GetKeyDown (KeyCode.P))					{myState = States.photo;}
	}
	
	
	void state_slippers () {
		text.text = "The slippers are the only thing that's not salmon. They seem so comfy and warm. Like " +
					"a sweet, soft furry cat. A flat cat one would walk on.\n\n" +
		
					"<b>Press T to take slippers or R to go back to your room.</b>";
		
		if (Input.GetKeyDown (KeyCode.T))						{item_slippers = true; myState = States.room;}
		else if (Input.GetKeyDown (KeyCode.R))					{myState = States.room;}
	}
	
	void state_door () {
		
		text.text = "Like everything else in the room, the door is salmon. Bad painting job with " +
					"that. A poster indicates the exits in case of fire but your eyes are not what " +
					"they used to be. Now you can only see pictures of smiley people on fire.\n\n" +
						
					"Good for them.\n\n";
		
		// Player doesn't have slippers in inventory.
		if (!item_slippers) {
			text.text = text.text + "The door is not locked and you can open it easily. Once you set "+
									"a foot outside, the freezing floor stops you from going further. " +
									"This illusion of freedom is obviously how they trap gullible " +
									"residents.\n\n" +
			
									"<b>Press R to go back to your room.</b>";
		}
		
		// Player already have slippers in inventory.
		else {
			text.text = text.text + "<b>Press L to leave the room or R to go back to your room.</b>";
		}
		
		if (Input.GetKeyDown (KeyCode.L) && (item_slippers))	{myState = States.corridor;}
		else if (Input.GetKeyDown (KeyCode.R))					{myState = States.room;}
	
	}
	
	void state_photo () {
		text.text = "It's a simple family picture of your step-familly. It's boring and therefore " +
					"fits well with the room. That's probably why the nurses keep putting it back on every " +
					"time you take it away. Or are they?\n\n" +
		
					"<b>Press T to take the photo frame or R to go back to your room.</b>";
					
		if (Input.GetKeyDown (KeyCode.T))						{myState = States.take_photo;}
		else if (Input.GetKeyDown (KeyCode.R))					{myState = States.room;}
	}
	
	void state_take_photo () {
		text.text = "Now you think about it, why would you take this? Love will just be a hindrance " +
					"in the quest for survival outside. Trust no one, especially not the step-children. " +
					"They look way too happy and smiley.\n\n" +
		
					"<b>Press R to go back to your room.</b>";
		
		if (Input.GetKeyDown (KeyCode.R))						{myState = States.room;}
	
	}
	
	void state_corridor () {
		text.text = "This is the corridor, empty, cold and with a strong smell of clean, as if " +
					"they put bleach on your face and used it to wash the floor. Everyone is " +
					"in their room at this time of the night, apart from the occasional resident " +
					"wandering the building and mumbling about pies in the kitchen.\n\n" +
					
					"There's a lift at the end of the corridor, a counter with drawers, a flower "+
					"vase nearby and some cupbards along the wall.\n\n" +
					
					"<b>Press D to search the drawers, L to go to the lift, C to look in " +
					"the cupboards and R to go back to your room.</b>";
					
		if (Input.GetKeyDown (KeyCode.D))						{myState = States.drawers;}
		else if (Input.GetKeyDown (KeyCode.L))					{myState = States.lift;}
		else if (Input.GetKeyDown (KeyCode.C))					{myState = States.cupboard;}
		else if (Input.GetKeyDown (KeyCode.R))					{myState = States.room;}
	}
	
	void state_drawers () {
			text.text = "Someone have forgotten to lock the counter drawers tonight. Unfortunately, " +
						"it seems someone got there before you. They are frustratingly empty. Damn it! \n\n";
			
			// Only if player has met Teresa in the lift already.
			if ((event_teresa) && (!item_crosswords) && (event_lift_blocked)) {
			text.text = text.text + "<b>Press S to search more or C to go back to the corridor.</b>";
			}
			
			// Player hasn't met Teresa yet and doesn't know what to look for.
			else {
				text.text = text.text + "<b>Press C to go back to the corridor.</b>";
			}
					
		if (Input.GetKeyDown (KeyCode.C))													{myState = States.corridor;}
		else if (Input.GetKeyDown (KeyCode.S) && (event_teresa) && (event_lift_blocked))	{myState = States.secret_drawers;}
	}
	
	void state_secret_drawers () {
	
		// Only happens once.
		text.text = "Wait a second... Your hand brushes past something. It feels like paper. After a quick " +
					"inspection, you discover a piece of newspaper taped to the top of the drawer. This old goat " +
					"managed to hid her stuff away from Bill. A good hiding spot you'd remember if you " +
					"were planning on spending a minute more in this place.\n\n" +
				
					"<b>Press T to take the crosswords or C to go back to the corridor.</b>";
					
		if (Input.GetKeyDown (KeyCode.T))						{item_crosswords = true; myState = States.drawers;}
		else if (Input.GetKeyDown (KeyCode.C))					{myState = States.corridor;}
	}
	
	void state_lift () {
	
		// Player cannot go further before sorting out problem.
		if (event_lift_blocked) {
			text.text = "An old lady in a wheelchair in inside the lift, blocking the access " +
						"to the buttons. It's old Teresa. She's pretty resilient and won't " +
						"move until she wants to. You have a vague memory of her fighting for " +
						"the latest newspaper with old Bill. \n\n";
					
			if (item_crosswords) {
				text.text = text.text + "<b>Press G to give the crossword and C to go back to the corridor.</b>";
			}
			
			else {
				text.text = text.text + "<b>Press C to go back to the corridor.</b>";
			}	
		}
		
		// Player has sorted the problem and have now free access.
		else {
			text.text = "The lift is empty. You can never remember which floor this is. But you can " +
						"try every button to figure it out. That often annoys the hell out of the " +
						"nurse.\n\n" +
						
						"<b>Press H to go the hall or C to go back to the corridor.</b>";
		}
		
		if (Input.GetKeyDown (KeyCode.G) && (item_crosswords))			{myState = States.give_crosswords;}
		else if (Input.GetKeyDown (KeyCode.C))							{event_teresa = true; myState = States.corridor;}
		else if (Input.GetKeyDown (KeyCode.H) && (!event_lift_blocked))	{myState = States.hall;}	
	}
	
	void state_cupboard () {
	
		text.text = "They are big cupboards that have been cleaned over and over again. You notice " +
					"the paint fading at some places. Like everything else here, it has a hospital " +
					"smell.\n\n";
	
		// Player doesn't have hobnobs in inventory.
		if (!item_hobnobs) {
			text.text = text.text + "Amazing! Someone left some hobnobs unguarded. This could be very " +
									"useful during harsh winters outside. As far as you know, the system " +
									"in place may have collapsed and hobnobs are the next currency in " +
									"Albion. \n\n" +
		
									"<b>Press T to take the hobnobs or C to go back to the corridor.</b>";			
		}
		
		// Player already have hobnobs in inventory.
		else {
			text.text = text.text + "And they are empty.\n\n" +
						
									"<b>Press C to go back to the corridor.</b>";
		}
					
		if (Input.GetKeyDown (KeyCode.T) && (!item_hobnobs))	{item_hobnobs = true; myState = States.corridor;}
		else if (Input.GetKeyDown (KeyCode.C))					{myState = States.corridor;}
	
	}
	
	void state_give_crosswords () {
	
		// Only happens once.
		text.text = "Teresa rolls forwards, as if she felt the object of her interest right away. " +
					"She leaves the lift as fast as she can (not very fast) and forcefully gives you " +
					"what she was holding: a pot of cranberry sauce. You don't feel like you can " +
					"refuse. You guess that's what grandchildren feel when given another another plate " +
					"of Brussels sprouts.\n\n" +
					
					"Oh well, it's barely open. Could be an important resource when you're out of here. " +
					"You're now in control of the lift.\n\n" +
								
					"<b>Press H to go the hall and C to go back to the corridor.</b>";
					
		item_crosswords = false;
		event_lift_blocked = false;
		item_cranberry = true;
		
		if (Input.GetKeyDown (KeyCode.H))						{myState = States.hall;}
		else if (Input.GetKeyDown (KeyCode.C))					{myState = States.corridor;}	
	}
	
	void state_hall () {
		text.text = "The hall floor consists of a very large room. During the day, many people come and go. " +
					"From nursing pushing residents wheelchairs, deliveries, people using the phones and " +
					"sometimes a few visits from relatives.\n\n" +
					
					"The reception room is right by the entrance and always occupied by the nurse on duty. " +
					"On the opposite side, there's a door with a sign indicating a tea room.\n\n" +
					
					"<b>Press T to move to the tea room, P to use the phone, R to go to the reception " +
					"and L to go back to the lift.</b>";
					
		if (Input.GetKeyDown (KeyCode.T))						{myState = States.tea_room;}
		else if (Input.GetKeyDown (KeyCode.P))					{myState = States.phone;}	
		else if (Input.GetKeyDown (KeyCode.R))					{myState = States.reception;}
		else if (Input.GetKeyDown (KeyCode.L))					{myState = States.lift;}	
		
	}
	
	void state_tea_room () {
		text.text = "Contrasting with the rest of the hall and corridors, the tea room is very colourful. " +
					"Very. As if the interior designer got only one directive : 'PLEASE MAKE IT POP'. " +
					"That or the owner's 6 year old nephew had an 'eye for design'. Everything is bright " +
					"and orange, and purple, and sky blue. Pictures of the residents in 'forced fun' " +
					"activities are displayed everywhere on the wall. You see yourself on the wall, with a " +
					"ridiculous paper hat.\n\n";
		
		// Player doesn't have the teaset in their inventory, add this:
		if (!item_teaset) {
			text.text = text.text + "There's a small tea set still in its cardboard. It includes a teapot, " +
									"a waste bowl, a sugar bowl, a creamer, a tea caddy, three cups with " +
									"matching spoons and some Earl Grey leaves. All of these are hand painted " +
									"with green toile patterns. Whoever left this here is too foolish to " +
									"deserve it.\n\n" +
		
									"<b>Press T to take the tea set or H to go back to the hall.</b>";
		}
		
		// Player already have teaset in their inventory.
		else {
			text.text = text.text + "<b>Press H to go back to the hall.</b>";
		}
		
		if (Input.GetKeyDown (KeyCode.T) && (!item_teaset))			{item_teaset = true; myState = States.tea_room;}
		else if (Input.GetKeyDown (KeyCode.H))						{myState = States.hall;}
	}
	
	void state_phone () {
		text.text = "Three public telephones are hanging on the wall. Residents can make phone calls to " +
					"their family. Or call the president. Or order food that isn't allowed. The hardest " +
					"part is to remember a number.\n\n";
		
		// All phone conversations have been made.
		if (phone_count == 3) {
			text.text = text.text + "<b>Press H to back to the hall.</b>";
		}
		
		// Some phone conversations are left.
		else {
			text.text = text.text + "<b>Press P to phone or H to go back to the hall.</b>";
		}
		
			if (Input.GetKeyDown (KeyCode.P) && (phone_count <= 2))		{phone_count++; myState = States.phonecall;}
			else if (Input.GetKeyDown (KeyCode.H))						{myState = States.hall;}
		}
	
	void state_phonecall () {

		if (phone_count == 1) {
			text.text = "Fortunately, the reception is on speed dial. You do your best to sound confused and "+
						"panicked, unlike your normal dominant and composed personality.\n\n" +
						
						"- There's a fire in room 45D! I'm trapped under a beam.\n" +
						"<i>- I'm monitoring the fire system and everything is fine. There's not even " +
						"smoke anywhere in the building.</i>\n" +
						"- Oh. Well, maybe a leak in the toilets instead?\n" +
						"<i>- Who is this?</i>\n\n" +
						
						"Uh-oh. You hang up. Damn you technology!\n\n" +
			
						"<b>Press P to carry on phoning or H to go back to the hall.</b>";
		}
		
		else if (phone_count == 2) {
			text.text = "<i>- Lucky Pizza, good evening! What can I do for you?</i>\n" +
						"- Errr... Can you send a Meat Feast with mushrooms to the Salmon & " +
						"Daisies Care Home?\n" +
						"<i>- This is the third time tonight! No, we do not make pizza smoothies, or sell plane " +
						"tickets to Jersey, and we can't fix your toilet leak. Please don't call " +
						"back. *click*</i>\n\n" +
						
						"How rude! If you had time, you would fill a complaint to her manager. Anyway, " +
						"what were you doing already...?\n\n" +
				
						"<b>Press P to carry on phoning or H to go back to the hall.</b>";
		}
			
		else if (phone_count == 3) {
			text.text = "These people are way too clever for their own good. It's time to use a " +
						"more impressive artillery. Speed dial room 34B.\n\n" +
						
						"- Good evening, Sir. This is a simple routine test. We believe there may be a " +
						"problem with your emergency cord. Could you please pull the cord for me?\n\n" +
						
						"Wait for a few seconds. Footsteps in the hall. Win.\n\n" +
				
						"<b>Press H to go back to the hall.</b>";
		}
		
		if (Input.GetKeyDown (KeyCode.P) && (phone_count == 1))			{phone_count++;} // Increment phone_count int
		else if (Input.GetKeyDown (KeyCode.H) && (phone_count == 1))	{myState = States.hall;}
		else if (Input.GetKeyDown (KeyCode.P) && (phone_count == 2))	{phone_count++;}
		else if (Input.GetKeyDown (KeyCode.H) && (phone_count == 2))	{myState = States.hall;}
		else if (Input.GetKeyDown (KeyCode.H) && (phone_count == 3))	{myState = States.hall;}
	}
	
	void state_reception () {
		text.text = "The reception is a small cabin with a glass directly contemplating the entrance of the " +
					"building. There's barely enough room for a desk and a computer.\n\n";
	
		// Player haven't distracted the nurse.
		if (phone_count <= 2) {
		
			// First time.
			if (!event_nurse) {
				text.text = text.text + "Despite your stealthy skills, the nurse notices you easily and asks " +
										"what you're doing here. He looks at you like he heard it all before " +
										"and, with a patronising attitude, tells you you should be in your " +
										"room.\n\n" +
									
										"This is clearly a prison. You know it.\n\n" +
									
										"<b>Press C to continue.</b>";
			}
			
			// Other times.
			else {
				text.text = text.text + "The nurse notices you even faster than last time. Damn it! His " +
										"detecting skills must have improved since.\n\n" +
										
										"And... back in the room.\n\n" +
										
										"<b>Press C to continue.</b>";
			}
		}
		
		// YAY! Player distracted the nurse, the passage is safe!
		else {
			text.text = text.text + "No one is in the reception room. The nurse finally left! According " +
									"to the doodles on the desk, he's not paid to do much in your opinion.\n\n" +
									
									"<b>Press E escape the building or H to go back to the hall.</b>";
		}
		
		if (Input.GetKeyDown (KeyCode.E) && (phone_count == 3)) {
		
			if ((item_cranberry) && (item_teaset) && (item_hobnobs))		{myState = States.freedom;} // all objects in inventory
			else 															{myState = States.missing_objects;} // missing objects
		}
		
		else if (Input.GetKeyDown (KeyCode.C) && (phone_count <= 2)) {
		
			if (!event_nurse)												{myState = States.caught;}
			else															{myState = States.room;}
			
		}
		
		else if (Input.GetKeyDown (KeyCode.H))								{myState = States.hall;}
	}
	
	void state_caught () {
	
		// Bringing the player back to the room (but leaving the inventory).
		text.text = "After an endless and awkward walk back, the nurse brings you to your room. He seems to " +
					"be skeptically eyeballing you and all the objects you're carrying with you. " +
					"Thank God for incompetent nursing students, he doesn't do anything about it and leaves " +
					"you on your own.\n\n" +
					
					"Does he think this is going to stop you?\n\n" +
					
					"<b>Press C to continue.</b>";
					
		event_nurse = true;
					
		if (Input.GetKeyDown (KeyCode.C))						{myState = States.room;}
		
	}
	
	void state_missing_objects () {
	
		// Player didn't have all the objects necessary to escape, need to go back and find the missing ones.
		text.text = "A doubt creeps in. Do you have enough food? Do you have what it takes to survive? " +
					"Better make sure you have everything before you brave the danger of outside.\n\n" +
					
					"<b>Press R to go back to the reception.</b>";
					
		if (Input.GetKeyDown (KeyCode.R))						{myState = States.reception;}
	}
	
	void state_freedom () {
		
		// Sucess! The player has escape!
		text.text = "You're finally out of this den of evil. Freedom and opportunities are yours! Holding " +
					"onto your bundle, you disappear into the night, swearing they'll never catch you. " +
					"Again.\n\n" +
					
					"<b>THE END</b>";
	}
	
}