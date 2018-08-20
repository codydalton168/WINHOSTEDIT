using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostEdit {
	public class InternalErrorException : Exception {
		public InternalErrorException(string message) : base(message) {
		}
	}
}
