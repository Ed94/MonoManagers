#pragma once
#include <GL\glew.h>
#include <vector   >
 
//This header is organized by pointer heirarchy instead of alphabetical order.
namespace AbstractRealm
{
	//Structs
	struct Color	  { GLubyte r, g, b, a; };
	struct Position2D { float   x, y	  ; };

	struct Vertex
	{
		Color	   color   ;
		Position2D position;
	};

	struct Triangle
	{
		GLubyte size = 6 * 3;

		struct VertData { Vertex v1, v2, v3; } vertData;

		void setColor   (GLubyte red, GLubyte green, GLubyte blue, GLubyte alpha					);
		void setPosition(float    x1, float		 y1, float	   x2, float	  y2, float x3, float y3);
	};

	struct Rectangle
	{
		GLubyte size = 6 * 12;

		struct Triangles { Triangle t1, t2; } triangles;

		Vertex* getDataArray();

		void setColor   (GLubyte   red, GLubyte green, GLubyte blue, GLubyte  alpha);
		void setPosition(float   right, float    left, float    top, float   bottom);
	};

	
	//Classes
	class Sprite
	{
	public:
		 Sprite();
		~Sprite();

		void initialize(float x, float y, float width, float height);

		void render();

	private:
		float     x,	  y;
		float width, height;

		GLuint vboID;

		Rectangle *rectPtr, rectangle;
	};
}