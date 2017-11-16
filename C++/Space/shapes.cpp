#include "2DObjects.h"

namespace AbstractRealm
{
	void Triangle::setColor(GLubyte red, GLubyte green, GLubyte blue, GLubyte alpha)
	{
		vertData.v1.color.r = red; vertData.v1.color.g = green; vertData.v1.color.b = blue; vertData.v1.color.a = alpha;
		vertData.v2.color.r = red; vertData.v2.color.g = green; vertData.v2.color.b = blue; vertData.v2.color.a = alpha;
		vertData.v3.color.r = red; vertData.v3.color.g = green; vertData.v3.color.b = blue; vertData.v3.color.a = alpha;
	}

	void Triangle::setPosition(float x1, float y1, float x2, float y2, float x3, float y3)
	{
		this->vertData.v1.position.x = x1; this->vertData.v1.position.y = y1;
		this->vertData.v2.position.x = x2; this->vertData.v2.position.y = y2;
		this->vertData.v3.position.x = x3; this->vertData.v3.position.y = y3;
	}

	Vertex* Rectangle::getDataArray()
	{
		Vertex *vertDataArray = new Vertex[6];

		vertDataArray[0] = triangles.t1.vertData.v1;
		vertDataArray[1] = triangles.t1.vertData.v2;
		vertDataArray[2] = triangles.t1.vertData.v3;
		vertDataArray[3] = triangles.t2.vertData.v1;
		vertDataArray[4] = triangles.t2.vertData.v2;
		vertDataArray[5] = triangles.t2.vertData.v3;

		return vertDataArray;
	}

	void Rectangle::setColor(GLubyte red, GLubyte green, GLubyte blue, GLubyte alpha)
	{
		triangles.t1.setColor(red, green, blue, alpha);
		triangles.t2.setColor(red, green, blue, alpha);
	}

	void Rectangle::setPosition(float right, float left, float top, float bottom)
	{
		this->triangles.t1.setPosition(right,    top,  left,	top,  left, bottom);
		this->triangles.t2.setPosition( left, bottom, right, bottom, right,	   top);
	}
}