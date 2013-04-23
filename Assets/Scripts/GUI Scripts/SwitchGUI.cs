using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*public class TextureGUI : MonoBehaviour 
{
Texture texture; //useful: texture.width, texture.height
Vector2 offset; // .x and .y
private Vector2 originalOffset; //store the original to correctly reset anchor point
	
private enum Point 
	{ 
		TopLeft = 0, 
		TopRight = 1, 
		BottomLeft = 2, 
		BottomRight = 3, 
		Center = 4,
	}; //what part of texture to position around?
	
float anchorPoint = (float)Point.TopLeft; // Unity default is from top left corner of texture
		
	void setAnchor() 
	{ // meant to be run ONCE at Start.
		originalOffset = offset;
		if (texture) 
		{ // check for null texture
			switch(anchorPoint) 
			{ //depending on where we want to center our offsets
				case anchorPoint.TopLeft: // Unity default, do nothing
					break;
				case anchorPoint.TopRight: // Take the offset and go to the top right corner
					offset.x = originalOffset.x - texture.width;
					break;
					
				case anchorPoint.BottomLeft: // bottom left corner of texture
					offset.y = originalOffset.y - texture.height;
					break;
					
				case anchorPoint.BottomRight: //bottom right corner of texture
					offset.x = originalOffset.x - texture.width;
					offset.y = originalOffset.y - texture.height;
					break;
					
				case anchorPoint.Center: //and the center of the texture (useful for screen center textures)
					offset.x = originalOffset.x - texture.width/2;
					offset.y = originalOffset.y - texture.height/2;
					break;
			}
		}
	}
}*/


// SwitchGUI Class: Extends the TextureGUI to be able to load in multiple textures and switch between them
public class SwitchGUI : MonoBehaviour 
{
public List<Texture> switchableTextures = new List<Texture>();
public int currentTexture = 0;
	
public Texture healthTex;
	
	void Start() 
	{
		if (switchableTextures.Count > 0) 
		{
			healthTex = switchableTextures[currentTexture];
		}
	}
	
	public void changeTexture(int switchTo) 
	{
		if (switchTo < switchableTextures.Count && switchTo >= 0) 
		{
			healthTex = switchableTextures[switchTo];
			currentTexture = switchTo;
		} 

	}
	
	void up() 
	{
		if ((currentTexture+1) < switchableTextures.Count) 
		{
			++currentTexture;
			healthTex = switchableTextures[currentTexture];
		} 

	}
	
	void nextTexture() 
	{
		if ((currentTexture+1) < switchableTextures.Count) 
		{ // if we are at the end of the array
			++currentTexture;
			healthTex = switchableTextures[currentTexture];
		} 
		else 
		{// loop to the beginning
			currentTexture = 0;
			healthTex = switchableTextures[currentTexture];
		}
	}
	
	void down() 
	{
		if ((currentTexture-1) >= 0) 
		{
			--currentTexture;
			healthTex = switchableTextures[currentTexture];
		} 

	}

}

/*class Location : MonoBehaviour
{
enum Point { TopLeft, TopRight, BottomLeft, BottomRight, Center}
	
float pointLocation = (float)Point.TopLeft;
Vector2 offset;
	
		
	void updateLocation() 
	{
		switch(pointLocation) 
		{
			case pointLocation.TopLeft:
				offset = Vector2(0,0);
				break;
			case pointLocation.TopRight:
				offset = Vector2(Screen.width,0);
				break;
				
			case pointLocation.BottomLeft:
				offset = Vector2(0,Screen.height);
				break;
				
			case pointLocation.BottomRight:
				offset = Vector2(Screen.width,Screen.height);
				break;
				
			case pointLocation.Center:
				offset = Vector2(Screen.width/2,Screen.height/2);
				break;
		}		
	}
}

class TextureAnchor : MonoBehaviour
{
enum Point { TopLeft, TopRight, BottomLeft, BottomRight, Center}
	
float anchorPoint = (float)Point.TopLeft;
Vector2 offset;
	
	void update() 
	{
		switch(anchorPoint) 
		{
			case anchorPoint.TopLeft:
				offset = Vector2(0,0);
				break;
			case anchorPoint.TopRight:
				offset = Vector2(Screen.width,0);
				break;
				
			case anchorPoint.BottomLeft:
				offset = Vector2(0,Screen.height);
				break;
				
			case anchorPoint.BottomRight:
				offset = Vector2(Screen.width,Screen.height);
				break;
				
			case anchorPoint.Center:
				offset = Vector2(Screen.width/2,Screen.height/2);
				break;
		}		
	}
}*/