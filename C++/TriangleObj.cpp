#include "TestObjects.h"

namespace AbstractRealm
{
	TriangleObj:: TriangleObj() { }
	TriangleObj::~TriangleObj() { }

	void TriangleObj::renderTriangle()
	{
		glEnableClientState(GL_COLOR_ARRAY);
		glBegin			   (GL_TRIANGLES  );

		glColor3f(145, 145, 145);

		glVertex2f(	0	 ,  0.25f);
		glVertex2f(-0.15f, -0.15f);
		glVertex2f( 0.15f, -0.15f);

		glEnd();
	}
}