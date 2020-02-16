using System;
namespace Decorator {

	public class Voiture
	{
		public double Prix { get; set; }

		public Voiture(double prix)
		{
			Prix = prix;
		}

		public override string ToString()
		{
			return "Prix de base du véhicule: " + Prix;
		}
	}
}

