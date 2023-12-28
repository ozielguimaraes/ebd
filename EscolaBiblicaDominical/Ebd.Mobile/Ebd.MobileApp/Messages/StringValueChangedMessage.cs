using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Ebd.MobileApp.Messages
{
    public class StringValueChangedMessage : ValueChangedMessage<string>
    {
        public StringValueChangedMessage(string value) : base(value)
        {
        }
    }
}
