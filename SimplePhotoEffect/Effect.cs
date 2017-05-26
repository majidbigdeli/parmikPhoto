using System.Runtime.Serialization;

namespace Photo.Effect.DataContract
{
    [DataContract]
    public enum Effects : int
    {
        Cartoonify = 1,
        Flagging = 2,
        TextAdder = 3,
    }
}