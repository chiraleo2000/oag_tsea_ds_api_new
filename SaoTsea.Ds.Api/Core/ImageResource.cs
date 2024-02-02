using System.IO;
using ImageMagick;
using Microsoft.AspNetCore.Http;

namespace SaoTsea.Ds.Api.Core
{
	public class ImageResource
	{
		public IFormFile File { get; set; }
		public Stream ImageStream { get; set; }
		public string Destination { get; set; }
		public string Name { get; set; } = "image";
		public MagickFormat Type { get; set; } = MagickFormat.Jpg;
		public string Extension { get; set; } = "jpg";
		public int Quality { get; set; } = 70;

		public string FullPath => Path.Combine(Destination, $"{Name}.{Extension}");
	}
}
