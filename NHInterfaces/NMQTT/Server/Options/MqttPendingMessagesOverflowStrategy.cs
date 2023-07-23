namespace System.Data.NMQTT
{
    public enum MqttPendingMessagesOverflowStrategy
    {
        DropOldestQueuedMessage,
        
        DropNewMessage
    }
}
