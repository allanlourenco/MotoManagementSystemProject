using MotoManagementSystemProject.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoManagementSystemProject.Service.Services
{
    public class ImageUploadService : IImageUploadService
    {
        private readonly string _imageFolderPath;

        public ImageUploadService()
        {
            _imageFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(_imageFolderPath))
            {
                Directory.CreateDirectory(_imageFolderPath);
            }
        }

        public async Task<string> UploadImageAsync(string base64Image)
        {
            // Converter Base64 para bytes
            var imageBytes = Convert.FromBase64String(base64Image);

            // Criar um nome único para a imagem
            var fileName = $"{Guid.NewGuid()}.jpg";
            var filePath = Path.Combine(_imageFolderPath, fileName);

            // Salvar a imagem no disco
            await File.WriteAllBytesAsync(filePath, imageBytes);

            // Retornar a URL onde a imagem está acessível
            var imageUrl = $"/uploads/{fileName}";
            return imageUrl;
        }
    }
}
