using System;
using Contract.Params;
using Contract.Responses;
using Core.AbstractApp;

namespace Core.Applictaion
{
    internal class AudioFileApplication : BaseApplication, IAudioFileApplication
    {
        public BaseResponse SaveFile(SaveFileParams @params)
        {
            throw new NotImplementedException();
        }
    }
}
