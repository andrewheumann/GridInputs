using Elements;
using System.Collections.Generic;

namespace GridInputs
{
	/// <summary>
	/// Override metadata for GridsOverride
	/// </summary>
	public partial class GridsOverride : IOverride
	{
        public static string Name = "Grids";
        public static string Dependency = null;
        public static string Context = "[*discriminator=Elements.GridAxisControl]";
		public static string Paradigm = "Edit";

        /// <summary>
        /// Get the override name for this override.
        /// </summary>
        public string GetName() {
			return Name;
		}

		public object GetIdentity() {

			return Identity;
		}

	}
}