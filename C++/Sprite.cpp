#include "2DObjects.h"
#include <iostream>
#include <cstddef>

namespace AbstractRealm
{
	Sprite::Sprite() : vboID(0) { }

	Sprite::~Sprite()
	{
		if (vboID != 0)
			glDeleteBuffers(1, &vboID);
	}

	void Sprite::initialize(float x, float y, float width, float height)
	{
		this->x = x; this->y = y; this->width = width;  this->height = height;

		if (vboID == 0)
			glGenBuffers(1, &vboID);

		rectPtr = &rectangle;

		rectangle.setPosition(x + width/2, x - width/2, y + height/2, y - height/2);

		rectangle.setColor	 (194, 20, 194, 255);

		rectangle.triangles.t1.vertData.v2.color.r = 12;
		rectangle.triangles.t1.vertData.v3.color.r = 12;
		rectangle.triangles.t2.vertData.v1.color.r = 12;

		glBindBuffer(GL_ARRAY_BUFFER,		  vboID											);
		glBufferData(GL_ARRAY_BUFFER, rectPtr->size, rectPtr->getDataArray(), GL_STATIC_DRAW);
		glBindBuffer(GL_ARRAY_BUFFER,			  0											);
	}

	void Sprite::render()
	{
		glBindBuffer(GL_ARRAY_BUFFER, vboID);

		glEnableVertexAttribArray(0);
		glEnableVertexAttribArray(1);

		glVertexAttribPointer(0, 2, GL_FLOAT	    , GL_FALSE, sizeof(Vertex), (void*)offsetof(Vertex, position));   //Position attribute pointer.
		glVertexAttribPointer(1, 4, GL_UNSIGNED_BYTE, GL_TRUE , sizeof(Vertex), (void*)offsetof(Vertex, color   ));   //Color    attribute pointer.

		glDrawArrays(GL_TRIANGLES, 0, 6);

		glDisableVertexAttribArray(0);
		glDisableVertexAttribArray(1);

		glBindBuffer(GL_ARRAY_BUFFER, 0);
	}
}