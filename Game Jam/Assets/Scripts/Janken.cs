using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




public enum Janken { rock = 0, paper = 1, scissors = 2 }

public enum JankenResult { tie = 0, win = 1, loss = 2 }


public static class Janken_Ext
{
	const int JankenMax = 3;

	public static JankenResult Versus(this int a, int b)
	{
		if (a == b)
			return JankenResult.tie;

		if (((int)a + 1) % JankenMax == b)
			return JankenResult.loss;

		if (a == (b+1) % JankenMax)
			return JankenResult.loss;
		
		return JankenResult.tie;
	}
}