using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using RunningGroupWebApp.Helpers;
using RunningGroupWebApp.Interfaces;

namespace RunningGroupWebApp.Services;

public class CloudinaryPhotoService : IPhotoService
{
	private readonly Cloudinary _cloudinary;

	public CloudinaryPhotoService(IOptions<CloudinarySettings> settings)
	{
		Account account = new(
			settings.Value.CloudName,
			settings.Value.ApiKey,
			settings.Value.ApiSecret
		);
		
		_cloudinary = new Cloudinary(account);
	}
	
	public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
	{
		var uploadResult = new ImageUploadResult();
		if(file.Length > 0 )
		{
			using var stream = file.OpenReadStream();
			var uploadParams = new ImageUploadParams()
			{
				File = new FileDescription(file.FileName, stream),
				Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")	
			};
			
			uploadResult = await _cloudinary.UploadAsync(uploadParams);
		}
		return uploadResult;
	}

	public async Task<DeletionResult> DeletePhotoAsync(string publicId)
	{
		DeletionParams deletionParams = new(publicId);
		var deletionResult = await _cloudinary.DestroyAsync(deletionParams);
		return deletionResult;
	}
	
	
}