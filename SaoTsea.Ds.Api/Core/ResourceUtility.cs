using System;
using System.IO;
using System.Threading.Tasks;
using ImageMagick;
using SaoTsea.Ds.Api.Models.ReadModels;

namespace SaoTsea.Ds.Api.Core
{
public class ResourceUtility
	{
		private AppSetting _settings;

		public ResourceUtility(
			AppSetting settings)
		{
			_settings = settings;
		}

		public string ResourcePath
		{
			get
			{
				string baseUploadPath = _settings.ResourcePath;
#if DEBUG
				baseUploadPath = "C:\\Resource";
#endif
				return baseUploadPath;
			}
		}

		public async Task SaveFile(FileResource info)
		{
			if (string.IsNullOrEmpty(info.Destination))
			{
				throw new ArgumentNullException(nameof(info.Destination));
			}

			if (info.FileStream == null && info.BytesData == null)
			{
				throw new ArgumentNullException("ไม่พบไฟล์ข้อมูล");
			}

			string baseUploadPath = ResourcePath;
			string fileFullname;
			if (string.IsNullOrEmpty(info.Extension))
			{
				fileFullname = $"{info.Name}";
			}
			else
			{
				fileFullname = info.Extension.StartsWith('.') ? $"{info.Name}{info.Extension}" : $"{info.Name}.{info.Extension}";
			}

			baseUploadPath = Path.Combine(baseUploadPath, info.Destination);
			string saveFullPath = Path.Combine(baseUploadPath, fileFullname);
			Directory.CreateDirectory(baseUploadPath);

			if (info.BytesData != null)
			{
				await File.WriteAllBytesAsync(saveFullPath, info.BytesData);
			}
			else
			{
				await using FileStream f = File.Create(saveFullPath);
				await info.FileStream.CopyToAsync(f);
			}
		}

		public async Task SaveImageToResource(ImageResource info)
		{
			if (string.IsNullOrEmpty(info.Destination))
			{
				throw new ArgumentNullException(nameof(info.Destination));
			}

			if (info.File == null && info.ImageStream == null)
			{
				throw new ArgumentNullException(nameof(info.File) + " AND " + nameof(info.ImageStream));
			}

			Stream imageStream = info.File != null ? info.File.OpenReadStream() : info.ImageStream;
			string baseUploadPath = ResourcePath;
			string fileFullname = $"{info.Name}.{info.Extension}";
			baseUploadPath = Path.Combine(baseUploadPath, info.Destination);
			string saveFullPath = Path.Combine(baseUploadPath, fileFullname);
			Directory.CreateDirectory(baseUploadPath);

			await Task.Run(() =>
			{
				using (imageStream)
				{
					using MagickImage image = new MagickImage(imageStream)
					{
						Format = info.Type,
						Quality = info.Quality
					};


					using FileStream f = File.Create(saveFullPath);
					image.Write(f);
				}
			});
		}
	}
}
