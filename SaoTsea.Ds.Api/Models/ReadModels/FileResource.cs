using System.IO;

namespace SaoTsea.Ds.Api.Models.ReadModels
{
	public class FileResource
	{
		public byte[] BytesData { get; set; }
		public Stream FileStream { get; set; }
		public string Destination { get; set; }
		public string Name { get; set; } = "file";
		public string Extension { get; set; }

		public string FullPath => Path.Combine(Destination, $"{Name}{(string.IsNullOrEmpty(Extension) ? "" : "." + Extension.TrimStart('.'))}").Replace("\\", "/");

		public bool FromResource { get; internal set; }
    }
}
