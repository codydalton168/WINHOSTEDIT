using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostEdit {
	internal static class Util {
		public static void Assume
		(
		    bool condition,
		    string message
		) {
			if (!condition) {
				throw new InternalErrorException(message);
			}
		}


		public static T AssumeNotNull<T>
		(
		    this T item
		) where T : class {
			Assume(item != null, "Unexpected null value!");
			return item;
		}

		public static void Assume
		(
		    bool condition
		) {
			Assume(condition, "The condition should not be false!");
		}

		public static IntPtr AssumeNonZero
		(
		    this IntPtr item
		) {
			Assume(item != IntPtr.Zero);
			return item;
		}

		public static bool PathContains(this string parent, string child) {
			parent.AssumeNotNull();
			child.AssumeNotNull();

			if (!parent.EndsWith("\\")) {
				parent = parent + "\\";
			}

			return
			    child.StartsWith(parent, StringComparison.OrdinalIgnoreCase) ||
			    parent.TrimEnd('\\').Equals(child, StringComparison.OrdinalIgnoreCase);
		}
	}

}
