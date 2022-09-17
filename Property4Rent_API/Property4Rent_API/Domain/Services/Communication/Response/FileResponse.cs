using Property4Rent.API.Resources;

namespace Property4Rent.API.Domain.Services.Communication.Response
{
    public class FileResponse : BaseResponse<FileResource>
    {

        public FileResponse(FileResource fileInfo) : base(fileInfo)
        { }


        public FileResponse(string message) : base(message)
        { }
    }
}