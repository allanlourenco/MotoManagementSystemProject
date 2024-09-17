using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoManagementSystemProject.Domain.Interfaces.Services
{
    public interface IImageUploadService
    {
        Task<string> UploadImageAsync(string base64Image);
    }
}
