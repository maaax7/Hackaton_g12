using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon_g12.Application.Services.Imagens
{
	public interface IImagemService
	{
		Tuple<BinaryData, string, string> ExtrairImagensDeVideo(byte[] video, int segundos);
	}
}
