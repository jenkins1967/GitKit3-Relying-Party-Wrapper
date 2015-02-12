using System.Reflection.Emit;

namespace GitKitClient.Responses
{
    public abstract class BaseResponse<TResponseType>:JsonDeserializeable<TResponseType>
    {
        public string Kind { get; set; }
    }
}