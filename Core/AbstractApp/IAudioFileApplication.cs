using Contract.Params;
using Contract.Responses;

namespace Core.AbstractApp
{
    public interface IAudioFileApplication
    {
        BaseResponse SaveFile(SaveFileParams @params); 
    }
}
