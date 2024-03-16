using FFMpegCore;
using Hackathon_g12.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.IO;
using System.IO.Compression;

namespace Hackathon_g12.Application.Services.Imagens
{
	public class ImagemService : IImagemService
	{
		public Tuple<BinaryData, string, string> ExtrairImagensDeVideo(byte[] byteArray, int segundos)
		{

			string directory = AppContext.BaseDirectory;
			string pathImagens = Path.Combine(directory, "Images");
			string pathVideo = Path.Combine(directory, "Videos");
			string pathZip = Path.Combine(directory, "Zip");

			if (!Directory.Exists(pathImagens))
				Directory.CreateDirectory(pathImagens);

			if (!Directory.Exists(pathVideo))
				Directory.CreateDirectory(pathVideo);

			if (!Directory.Exists(pathZip))
				Directory.CreateDirectory(pathZip);


			var nameVideo = $"video-{DateTime.Now.ToString("yyyyMMddHHmmss")}.mp4";
			var nameZip = $"video-{DateTime.Now.ToString("yyyyMMddHHmmss")}.zip";
			var videoPath = @$"{pathVideo}\{nameVideo}";

			File.WriteAllBytes(videoPath, byteArray);

			var videoInfo = FFProbe.Analyse(videoPath);

			var duration = videoInfo.Duration;
			var interval = TimeSpan.FromSeconds(segundos);

			for (var currentTime = TimeSpan.Zero; currentTime < duration; currentTime += interval)
			{
				Console.WriteLine($"Processando frame: {currentTime}");
				var outputPath = Path.Combine(pathImagens, $"frame_at_{currentTime.TotalSeconds}.jpg");
				FFMpeg.Snapshot(videoPath, outputPath, new Size(1920, 1080), currentTime);
			}

			var zipFile = @$"{pathZip}\{nameZip}";

			ZipFile.CreateFromDirectory(pathImagens, zipFile);

			byte[] fileBytes = File.ReadAllBytes(zipFile);
			return new Tuple<BinaryData, string, string>(new BinaryData(fileBytes), nameVideo, nameZip);
		}
	}
}
