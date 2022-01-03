using Elements;
using System.Collections.Generic;

namespace GridInputs
{
	/// <summary>
	/// Override metadata for DGridsOverride
	/// </summary>
	public partial class DGridsOverride : IOverride
	{
        public static string Name = "2d Grids";
        public static string Dependency = null;
        public static string Context = "[*discriminator=Elements.GridAxisControl2d]";
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