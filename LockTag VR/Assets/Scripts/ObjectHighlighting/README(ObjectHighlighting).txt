
**OBJECT HIGHLIGHTING**		  ++++++++++++++
							 ++++++++++++++++
						     000/000000000/00
							 00/00------/0000
							 0/000------00/00
							  ------||-------
							  ---++++++++---					 
							  ---+||||||+---
							  ++++||||||++++
							  ++++++++++++++
							   ++++++++++++
							    

-In order to get the object highlighting feature to work correctly you will want to make sure you follow these steps when setting it up from scratch.

	-Setup an empty gameobject in the hierarchy list (Create, Create Empty) and name it Highlight Manager.
	
	-Attach the Highlight script and Oultine Manager Script to the game object.
	
	-In your scene, objects you want to be able to highlight will require a tag name "Hightlightable". Be sure objects you intend to highlight have a the tag name "Hightlightable".
	
	-go into the Highlight script which should be in your Highlight Manager object located on the hierarchy list. You will notice a few methods that will be commented out. All you have to do is un-comment the one you want to use.
	
	-Be aware that the two Coroutine methods are there to test out turning off highlighted objects when you either use OutlineAll or Outline, ie...Simulating a situation where you might have a method turn off outlining when a task is completed.
	
	----If you use the LiveHighlighting() method then you will be able to highlight objects individually through the inspector. After you uncomment the LiveHighlighting() method, hit play on to start the scene and you will notice that your 
	 highlightable objects now have an extra script attached to them named Live Highlighting Manager. In the inspector on the Live Highlighting Manager component you will notice a Boolean variable named isHighlighted. Simply turn this on
	 or off and you will highlight or un-highlight the object.

	 ------One last thing, in the Highlight Manager object you will notice on the  Oultine Manager component (located on the inspector) a boolean variable named Refresh List that acts like a button. This button when pressed you will give you a 
	       message on the console that reads out what is currently highlighted in your scene. 

	