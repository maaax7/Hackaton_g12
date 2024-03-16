using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon_g12.Application.Services.Storage
{
	public interface IStorageService
	{
		Task UploadFile(BinaryData binaryData, string nome);
	}
}
