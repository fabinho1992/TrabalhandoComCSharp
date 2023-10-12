using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_ATENDIMENTO.ByteBankExecoes
{

	[Serializable]
    public class ByteBankExecao : Exception
	{
		public ByteBankExecao() { }
		public ByteBankExecao(string message) : base("Aconteceu uma EXEÇÃO ->" + message) { }
		public ByteBankExecao(string message, Exception inner) : base(message, inner) { }
		protected ByteBankExecao(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
