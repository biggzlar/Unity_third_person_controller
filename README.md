# Unity_third_person_controller
A very simple third person controller including character movement- and camera script. It runs smoothly and the camerascript implements a method to compensate for walls and obstacles between camera and character positions.

###Setup:
*It is highly recommended to check out the included example scene, to get a grasp on what the scripts' public values should look like.*

1. Set up a scene with main camera and a player object with character controller (remember to tag them as player and main camera if necessary)

2. Set the layer of the player object to something like "Player Layer" (this is important to have the camera ignore the player when trying to compensate for obstacles - alternatively you can go and change the layermask directly)

3. Assign the objects' transforms accordingly - PlayerMovement needs the camera's transform, CameraMovement needs the player's

4. Put in some reasonable values for speeds

There is an optional step three:
3.1 Instead of directly assigning the transforms to each other you can add another gameObject to your scene (make sure it's nobody's child)

3.2 Add to it the breathe script, than put its transform into the CameraMovement component

This will add some easing to the camera movement, adding this functionality to the CameraMovement.cs is definitely on the ToDo list for this project.

![Alt text](ThirdPersonPreview.png?raw=true "Third Person Preview")
