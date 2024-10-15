using CloudinaryDotNet.Actions;

namespace RunningGroupWebApp.Interfaces;

public interface IPhotoService
{
	Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
	Task<DeletionResult> DeletePhotoAsync(string publicId); 
}