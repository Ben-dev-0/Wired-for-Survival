using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F1Dialogue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            string spriteName = gameObject.name;

            switch (spriteName)
            {
                case "F1-1":
                    /*Dialogue 1 (Plays upon loading into the first level)
Alex: Man, sneaking in here was way easier than I ever could have guessed. At this rate, I’ll be on Tartarus in no time!
(The lights shut off, and the sound of the ship coming to a halt can be heard.)
Alex: What the? Did the power just go out?
Alex: …
Alex: The ship just stopped. That’s not good.
Alex: I can’t let anyone know I’m here, but I need to figure out what’s going on.
Alex: I’ll just take a quick look around. Hopefully no one’s nearby.
 */
                    break;
                case "F1-2":
                    /* Dialogue 2 (Plays when running into the closed doors)
Alex: Great. Doors won’t open. I’ll need to find some way of getting the power back on if I want to get out of here.

*/
                    break;
                case "F1-3":
                    /* Dialogue 3 (Plays when stepping on a certain square in the top right room)
Alex: What’s this? Some kind of tablet?
ADA: Greetings, user!
Alex: Gah! What the!?
ADA: I am ADA, your personal Automatis Device Actuator unit. How may I assist you today?
Alex: Uh, hi. Do you have any idea what’s going on? The ship just stopped randomly.
ADA: It appears that I no longer have any connection to the ship’s mainframe. We will need to reestablish connection to the if we wish to restore power to the ship.
Alex: Alright, but the way out is locked. How are we supposed to get you hooked back up if we can’t even get out of here?
ADA: Not to worry. I am equipped with the necessary information regarding restoration of ship functionality. Simply bring me to wherever there appears to be a malfunction and I will assist you in the process of repairing it.

Dialogue 4 (Plays when running into the closed doors with ADA)
Alex: Aren’t these doors supposed to open automatically when the power goes out?
ADA: I’m afraid not. Those Security Simulation games that have gotten quite popular recently are sadly not congruent with real world technology.
Alex: Alright. Well, let’s see if we can’t get this thing working.
ADA: Very well then. Attach me to the door and I will guide you through the process of repairing the power circuit.
*/
                    break;
                case "F1-4":
                    /* Dialogue 6 (Plays when reaching the light puzzle)
Alex: Looks like this is the control room.
ADA: Excellent. Let us repair this circuit as well.
*/
                    break;
                case "F1-5":
                    /* Dialogue 8 (Plays when standing on the table with the note)
Alex: What’s this? Some kind of note.
Alex: Something about “Dr. Ryan Andrews” and an experiment he’s been working on…
Alex: I should hang on to this. Might give us some insight as to what’s going on here.
	(Note table is replaced by regular table, acting like it has been collected.)
*/
                    break;
                case "F1-6":
                    /*Dialogue 9 (Plays when reaching the second door puzzle)
Alex: Another locked door.
ADA: We can repair this the same way as before.
*/
                    break;
                case "F1-7":
                    /*Dialogue 10 (Plays after finishing the second door puzzle, shows a creature walking down the hall)
Alex: Gasp! What the hell is that thing?!
ADA: It appears to be some sort of specimen.
Alex: Yeah, I got that part, but what is it?!
ADA: It doesn’t seem to match anything within my database. Perhaps it is the source of the motion detected earlier.
ADA: Until we can confirm more, it is best to remain cautious. This specimen could be dangerous.
Alex: What should we do? It’s standing right in front of where we need to go!
ADA: Just to our right is the cafeteria. If we can trigger the fire alarm, that should distract the specimen and allow us to pass by unnoticed.
Alex: Alright, let’s try it.
 */
                    break;
                default:
                    
                    break;
            }
        }
    }
}