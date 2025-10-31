# Unity Parallax Scrolling

2D Parallax Scrolling in Unity.

Based on the "[Parallax Background](https://www.youtube.com/watch?v=bhR4d2KgNO4&list=PLyH-qXFkNSxmDU8ddeslEAtnXIDRLPd_V&index=7)" video of the "2D Platformer Crash Course" YouTube series from [Chris' Tutorials](https://www.youtube.com/@ChrisTutorialsYT).\
The implemented parallax contained bugs and issues (such as reverse arallax effect), which have been corrected in this implementation.

Additionally, the "cycle" feature was added, to have infinite backgrounds (repeatable elements as the camera moves).


## Usage

**TODO:** REWRITE! (+add screenshots)

- have a game object ready to serve as the player
	=> will be tracked/followed by the camera
	The object's Z position will be considered as the "central" distance, not under parallax effect.
	Generally player on Z=0, but not required.
	Objects with lower Z will be in front and have higher parallax effect the further they are from the player.
	Objects with higher Z will be behind and have higher parallax effect the further they are from the player.

	For testing:
	- create a new empty object, and assign it a sprite or shape/volume.
	- Let's call it "Player".
	- attach the sample script `TestMove` basic inputs.
	- set an InputSystem Actions (eg default one) for the "Input Actions" property.

- have a camera ready in the scene, that follow the player
	For testing:
	- attach sample script `TestFollow` to the scene camera.
	- set the "Player" object for the "Follow" property.

- create background manager (rename?)
	- create empty object, rename eg "Background"
	- add `ParallaxScroller` script component

- camera, player and background game objects should be aligned on (X, Y) position, with different Z (ideally camera.z < player.z < horizon.z).

- create horizon
	! - Object is required, but doesn't need renderable component.
	- create child game object of bkg manager.
		=> will not move, follow the camera movement.
X		eg a 3D plane, align it to camera (-90 on X axis to face camera)
		=> create Sprite!
			+ assign texture
	- move it along Z at desired position (can be left at 0 locally (inside its parent).
		! - The closest the horizon and the player are on the Z axis, the stronger the parallax effect will be.
		To avoid bugs, they should not be at the same Z position, and the player should be "in front" of the horizon (smaller Z value).
	- resize to fit camera frustrum.
	- add `ParallaxItem` script component

- set background manager properties:
	- scene camera for "Camera"
	- horizon object for "Horizon"
	- Player object for "Follow"

- create parallax layers
	for each layer:
	- If want repetition when scrolling:
		- create empty object, rename it as desired (eg "LayerBack", LayerFront", etc.)
		- add `ParallaxItem` script component
		- add `CycleScroller` script component
		- create child game object that will contain the "scrolling" data (rephrase!)
			eg a Sprite
		- move along Z at desired position/distance of camera
			Ideally in front of background.
			(further from player => higher parallax effect, different direction if front/back)
		+ scale, rename...
		- set the child object as the "Item" property of the layer object.
		- set the scene camera as the "Camera" property of the layer object.
		- set horizontal and vertical scrolling properties as desired.
	- If don't want repetition when scrolling:
		- create child game object that will contain the "scrolling" data (rephrase!)
			eg a Sprite
		- move along Z at desired position/distance of camera
			(further from player => higher parallax effect)
		+ scale, rename...
	! - Layer objects should only have their Z position property changed (set to desired Z depth with camera, player, and horizon), all other transform properties should be the identity.
